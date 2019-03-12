using Microsoft.WindowsAzure.Storage.Table;

namespace AzureMessageBus.AzureTable
{
    public class JsonValueTableEntity : TableEntity
    {
        public string Value { get; set; }

        //public bool IsActive { get; set; }

        //public DateTimeOffset DataTimeModified { get; set; }
    }
}
