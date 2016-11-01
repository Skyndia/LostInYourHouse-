extern alias Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using ClientApplicationWF;
using System.Net.Sockets;
using System.IO;
using System.Drawing;

namespace ServerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Trigger the method PrintIncomingMessage when a packet of type 'Message' is received
            //We expect the incoming object to be a string which we state explicitly by using <string>
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("Message", PrintIncomingMessage);
            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0));

            //Print out the IPs and ports we are now listening on
            Console.WriteLine("Server listening for TCP connection on:");
            foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
                Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);

            //Let the user close the server
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);

            //We have used NetworkComms so we should ensure that we correctly call shutdown
            NetworkComms.Shutdown();
        }

        /// <summary>
        /// Writes the provided message to the console window
        /// </summary>
        /// <param name="header">The packet header associated with the incoming message</param>
        /// <param name="connection">The connection used by the incoming message</param>
        /// <param name="message">The message to be printed to the 
        /// </param>
        private static void PrintIncomingMessage(PacketHeader header, Connection connection, string message)
        {
            //Calculate the best path
            //-1 build a graph with the data
            Blueprint plan = Converter.Newtonsoft.Json.JsonConvert.DeserializeObject<Blueprint>(message);
            Graph graph = new Graph();
            graph.Build(plan);

            //-2 Find the best path in the graph
            Dijkstra Algo = new Dijkstra(graph);
            try
            {
                Algo.Run();
                List<Point> solution = Algo.GetResult();

                string sSolution = Converter.Newtonsoft.Json.JsonConvert.SerializeObject(solution);

                //Send the result
                connection.SendObject("Message", sSolution);
                Console.WriteLine("Sent as answer : " + sSolution);
            }
            catch (Exception e)
            {
                Console.WriteLine("error : " + e.Message);
            }
            
            
        }
    }
}