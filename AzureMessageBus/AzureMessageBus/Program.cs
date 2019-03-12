using System;
using System.Text;
using System.Threading.Tasks;
using AzureMessageBus.AzureTable;
using AzureMessageBus.Config;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureMessageBus
{
    class Program
    {
        private static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            LoadConfiguration();

            var serviceProvider = ConfigureService();

            serviceProvider.GetService<UseAzureTable>().WriteData().GetAwaiter();

            //var messageBusrManager = new AzureServiceBusManager();
            ////RunQueueAsync().GetAwaiter().GetResult();
            //messageBusrManager.RunTopicAync().GetAwaiter().GetResult();


        }

        private static ServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.Configure<AzureTableSettings>(Configuration.GetSection("AzureTableSettings"));

            return serviceCollection.BuildServiceProvider();

        }

        private static void LoadConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();
        }
    }

    class AzureServiceBusManager
    {
        const string ServiceBusQueueConnectionString = "Endpoint=sb://";
        const string ServiceBusTopicConnectionString = "Endpoint=sb://";
        const string QueueName = "reinz";
        const string TopicName = "mytopic";

        IQueueClient queueClient;
        ITopicClient topicClient;

        public async Task RunTopicAync()
        {
            const int numberOfMessage = 10;

            topicClient = new TopicClient(ServiceBusTopicConnectionString, TopicName);

            await SendTopicMessageAsync(numberOfMessage);

            Console.ReadKey();

            await topicClient.CloseAsync();
        }

        private async Task SendTopicMessageAsync(int numberOfMessage)
        {
            try
            {
                for (int i = 0; i < numberOfMessage; i++)
                {
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    Console.WriteLine($"Sending message: {messageBody}");


                    await topicClient.SendAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {ex.Message}");
            }
        }

        private async Task RunQueueAsync()
        {
            const int numberOfMessage = 10;
            queueClient = new QueueClient(ServiceBusQueueConnectionString, QueueName);

            await SendQueueMessageAsync(numberOfMessage);

            Console.ReadKey();

            await queueClient.CloseAsync();
        }

        private async Task SendQueueMessageAsync(int numberOfMessage)
        {
            try
            {
                for (int i = 0; i < numberOfMessage; i++)
                {
                    var messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    Console.WriteLine($"Sending message: {messageBody}");

                    await queueClient.SendAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {ex.Message}");
            }
        }
    }
}
