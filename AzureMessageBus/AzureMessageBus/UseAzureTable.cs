using System;
using System.Threading.Tasks;
using AzureMessageBus.AzureTable;
using Newtonsoft.Json;

namespace AzureMessageBus
{
    public class UseAzureTable
    {
        private readonly IAzureTableStorage<JsonValueTableEntity> _azure;

        public UseAzureTable(IAzureTableStorage<JsonValueTableEntity> azure)
        {
            _azure = azure;
        }

        public void ReadData()
        {

        }

        public async Task WriteData()
        {
            var result = GetTempDataAsync();

            try
            {
                var item = new JsonValueTableEntity()
                {
                    Value = result,
                    PartitionKey = "partitionKey",
                    RowKey = Guid.NewGuid().ToString()
                };

                await _azure.Insert(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string GetTempDataAsync()
        {
            return JsonConvert.SerializeObject(new SampleData()
            {
                Id = Guid.NewGuid(),
                Name = "SampleData",
                Address = "NZ, Auckland",
                Note = "Sample data"
            });
        }
    }

    public class SampleData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

    }
}
