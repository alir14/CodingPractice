using System;
using System.Collections.Generic;
using System.Text;

namespace AzureMessageBus
{
    public class Constants
    {
        public const string ConfigFileName = "appsettings.json";

        //Serilog config 
        public const string LogFilePath = "logs/log.txt";
        public const long OneMb = 1048576;
        public const string Assembly = "Assembly";
        public const string Version = "Version";
        public const string ReleaseId = "ReleaseId";

        //Application Config
        public const string AzureTableConfigName = "AzureTableSettings";
        public const string ReinzConfigName = "Reinz";
        public const string SeriLogConfigName = "Seq";
        public const string FeedConfigName = "Feed";

        //Azure filter item
        public const string PartitionKeyFilterParam = "partitionKey";
        public const string FromTimestampFilterParam = "fromTimestamp";

        //table Storage
        public const string PartitionKeyValue = "Residential";
    }
}
