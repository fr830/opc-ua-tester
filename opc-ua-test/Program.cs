using OpcLabs.EasyOpc.UA;
using System;
using System.Threading;

namespace opc_ua_test {
    class Program {
        static void Main(string[] args) {

            if (args.Length < 2) {
                Console.WriteLine("Not enough args :(");
                return;
            }

            UAEndpointDescriptor server = $"opc.tcp://{args[0]}";

            // How to keep quotes in user input string? :thinking:
            UANodeDescriptor node = args[1];

            EasyUAClient client = new EasyUAClient();

            UAAttributeData data;

            while (true) {

                data = client.Read(server, node);

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"Read timestamp: {data.SourceTimestampLocal}");
                Console.WriteLine($"Read status: {data.StatusCode}");
                Console.WriteLine($"Read value type is: {data.ValueType}");
                Console.WriteLine($"Read value is: {data.Value}");

                Thread.Sleep(500);
            }
        }
    }
}
