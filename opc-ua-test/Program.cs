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

            while (true) {
                Console.Clear();

                ReadNode(client, server, node);

                Thread.Sleep(500);
            }
        }

        static void ReadNode(EasyUAClient client, UAEndpointDescriptor server, UANodeDescriptor node) {
            UAAttributeData data = client.Read(server, node);

            Console.WriteLine($"Node: {node.NodeId}");
            Console.WriteLine($"Timestamp {data.SourceTimestampLocal}");
            Console.WriteLine($"Status: {data.StatusCode}");
            Console.WriteLine($"ValueType: {data.ValueType}");
            Console.WriteLine($"Value: {data.Value}");
        }
    }
}
