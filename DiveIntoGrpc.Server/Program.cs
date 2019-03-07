using System;
using DiveIntoGrpc.Shared;
using Grpc.Core;

namespace DiveIntoGrpc.Server
{
    class Program
    {
        private static void Main()
        {
            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Services = { ValueService.BindService(new ValueServiceImpl()) },
                Ports = { new ServerPort("localhost", ServerDetails.Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + ServerDetails.Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
