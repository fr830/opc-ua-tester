using OpcLabs.EasyOpc.UA;
using System;
using System.Collections.Generic;
using System.Threading;

namespace opc_ua_test {
    class Program {
        static void Main(string[] args) {

            if (args.Length < 2) {
                Console.WriteLine("Not enough args :(");
                return;
            }

            List<UANodeDescriptor> nodes = new List<UANodeDescriptor>();
            for (int i = 1; i < args.Length; i++) {
                nodes.Add(args[i]);
            }

            UAEndpointDescriptor server = $"opc.tcp://{args[0]}";

            EasyUAClient client = new EasyUAClient();

            while (true) {
                Console.Clear();

                foreach (UANodeDescriptor node in nodes) {
                    ReadNode(client, server, node);
                    Console.WriteLine();
                }

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
