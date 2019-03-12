using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMessageBus.Config;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureMessageBus.AzureTable
{
    public class AzureTableStorage<T> : IAzureTableStorage<T> where T : TableEntity, new()
    {
        private readonly IOptions<AzureTableSettings> _azureSetting;

        private CloudTable StorageTable
        {
            get
            {
                var storageAccount = new CloudStorageAccount
                (
                    new StorageCredentials(_azureSetting.Value.StorageAccount, _azureSetting.Value.StorageKey),
                    true
                );

                var tableClient = storageAccount.CreateCloudTableClient();

                var table = tableClient?.GetTableReference(_azureSetting.Value.TableName);

                table.CreateIfNotExistsAsync();

                return table;
            }
        }

        public AzureTableStorage(IOptions<AzureTableSettings> azureSetting)
        {
            _azureSetting = azureSetting;
        }

        public async Task Delete(string partitionKey, string rowKey)
        {
            var item = await ReturnItem(partitionKey, rowKey);

            var operation = TableOperation.Delete(item);

            await StorageTable.ExecuteAsync(operation);
        }

        public async Task<T> GetItem(string partitionKey, string rowKey)
        {
            return await ReturnItem(partitionKey, rowKey);
        }

        public async Task<List<T>> GetAll(string partitionKey)
        {
            var query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition
            (
                Constants.PartitionKeyFilterParam, QueryComparisons.Equal, partitionKey
            ));

            return await RetrieveRecords(query);
        }

        public async Task<List<T>> GetAll(string partitionKey, DateTime fromTimestamp)
        {
            var query = new TableQuery<T>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition(Constants.PartitionKeyFilterParam, QueryComparisons.Equal, partitionKey),
                    TableOperators.And,
                    TableQuery.GenerateFilterConditionForDate(Constants.FromTimestampFilterParam, QueryComparisons.GreaterThanOrEqual, fromTimestamp)));

            return await RetrieveRecords(query);
        }

        public async Task<List<T>> GetAllActive(string partitionKey)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T item)
        {
            try
            {
                var operation = TableOperation.Insert(item);

                var result = StorageTable.ExecuteAsync(operation).Result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public async Task Update(T item)
        {
            var operation = TableOperation.InsertOrReplace(item);

            await StorageTable.ExecuteAsync(operation);
        }

        #region Private Methods

        private async Task<T> ReturnItem(string partitionKey, string rowKey)
        {
            var operation = TableOperation.Retrieve<T>(partitionKey, rowKey);

            var result = await StorageTable.ExecuteAsync(operation);

            return (T)result.Result;
        }

        private async Task<List<T>> RetrieveRecords(TableQuery<T> query)
        {
            var results = new List<T>();

            TableContinuationToken continuationToken = null;

            do
            {
                var queryResults =
                    await StorageTable.ExecuteQuerySegmentedAsync(query, continuationToken);

                continuationToken = queryResults.ContinuationToken;

                results.AddRange(queryResults.Results);

            } while (continuationToken != null);

            return results;
        }

        #endregion
    }

}
