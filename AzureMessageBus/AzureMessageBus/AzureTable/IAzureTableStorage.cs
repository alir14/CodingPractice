using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureMessageBus.AzureTable
{
    public interface IAzureTableStorage<T> where T : TableEntity, new()
    {
        Task Delete(string partitionKey, string rowKey);
        Task<T> GetItem(string partitionKey, string rowKey);
        Task<List<T>> GetAll(string partitionKey);
        Task<List<T>> GetAll(string partitionKey, DateTime fromTimestamp);
        Task<List<T>> GetAllActive(string partitionKey);
        Task Insert(T item);
        Task Update(T item);
    }
}
