using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureMessageBus
{
    class Program
    {
        const string ServiceBusQueueConnectionString = "Endpoint=sb://";
        const string ServiceBusTopicConnectionString = "Endpoint=sb://";
        const string QueueName = "reinz";
        const string TopicName = "mytopic";
        static IQueueClient queueClient;
        static ITopicClient topicClient;


        static void Main(string[] args)
        {
            //RunQueueAsync().GetAwaiter().GetResult();
            RunTopicAync().GetAwaiter().GetResult();
        }

        private async static Task RunTopicAync()
        {
            const int numberOfMessage = 10;

            topicClient = new TopicClient(ServiceBusTopicConnectionString, TopicName);

            await SendTopicMessageAsync(numberOfMessage);

            Console.ReadKey();

            await topicClient.CloseAsync();
        }

        private async static Task SendTopicMessageAsync(int numberOfMessage)
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
            catch(Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {ex.Message}");
            }
        }

        private async static Task RunQueueAsync()
        {
            const int numberOfMessage = 10;
            queueClient = new QueueClient(ServiceBusQueueConnectionString, QueueName);

            await SendQueueMessageAsync(numberOfMessage);

            Console.ReadKey();

            await queueClient.CloseAsync();
        }

        private async static Task SendQueueMessageAsync(int numberOfMessage)
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
            catch(Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {ex.Message}");
            }
        }
    }
}
