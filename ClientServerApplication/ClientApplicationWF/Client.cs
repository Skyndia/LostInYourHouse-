extern alias Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using NetworkCommsDotNet;
using Jconverter = Converter.Newtonsoft.Json.JsonConvert;
using System.Threading;
using System.IO;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using System.Drawing;

namespace ClientApplicationWF
{
    public class Client
    {
        public int targetPort { get; set; }
        public string targetIp { get; set; }
        public bool connected { get; set; }
        private int answerTimeout { get; set; }
        private TcpClient tcpClient;
        private List<Point> answer { get; set; }

        public Client()
        {
            tcpClient = new TcpClient();
            connected = false;
            answerTimeout = 2000;
            //reset the answer
            answer = new List<Point>();
        }

        public Client(string IP, int port)
        {
            targetPort = port;
            targetIp = IP;
            tcpClient = new TcpClient();
            connected = false;
            answerTimeout = 2000;
            //reset the answer
            answer = new List<Point>();
        }

        public Client(string ipAndPort)
        {
            //Parse the necessary information out of the provided string
            targetIp = ipAndPort.Split(':').First();
            targetPort = int.Parse(ipAndPort.Split(':').Last());
            tcpClient = new TcpClient();
            connected = false;
            answerTimeout = 2000;
            //reset the answer
            answer = new List<Point>();
        }

        private void Data_Received(PacketHeader packetHeader, Connection connection, string incomingObject)
        {
            answer = Jconverter.DeserializeObject<List<Point>>(incomingObject);
        }

        public List<Point> GetAnswer()
        {
            return answer;
        }

        public void setTarget(string ip, int port)
        {
            tcpClient = new TcpClient();
            connected = false;
            targetIp = ip;
            targetPort = port;
        }

        public bool Connect()
        {
            bool res = true;

            
            try
            {
                tcpClient.Connect(targetIp, targetPort);
                NetworkComms.AppendGlobalIncomingPacketHandler<string>("Message", Data_Received);
                Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0));
            }
            catch
            {
                res = false;
                Console.WriteLine("error01");
            }
            connected = res;
            return res;
        }

        public void Disconnect()
        {
            if (connected)
            {
                tcpClient = new TcpClient();
                Connection.StopListening();
            }
        }

        public void Send(string message)
        {
            //reset the answer
            answer = new List<Point>();

            if (connected)
                NetworkComms.SendObject("Message", targetIp, targetPort, message);
        }

        public void Send(Blueprint message)
        {
            //reset the answer
            answer = new List<Point>();

            if (connected)
            {
                string sMessage;
                sMessage = Jconverter.SerializeObject(message);
                NetworkComms.SendObject("Message", targetIp, targetPort, sMessage);
            }
        }

        /*
        internal List<int> ReadAnswer(out bool ok)
        {
            List<int> result = new List<int>();
            ok = false;

            byte[] dataRead = new byte[0];

            //Get the current time and add answerTimeout (the maximum time we wait for the answer
            DateTime timeOut = new DateTime();
            timeOut = DateTime.Now;
            timeOut = timeOut.AddMilliseconds(answerTimeout);

            //Initial status
            string status = "Waiting for Data";

            //We want to loop for 500ms
            while (DateTime.Now.CompareTo(timeOut) < 0)
            {
                switch (status)
                {
                    //We are waiting for an answer
                    case "Waiting for Data":
                        Console.WriteLine("coucou");
                        //if there is something to be read
                        if (stream.DataAvailable)
                        {
                            //Start reading 
                            status = "Reading";

                            //The answer has 300ms to arrive
                            timeOut = DateTime.Now.AddMilliseconds(300);
                        }
                        break;

                    //We are reading the answer
                    case "Reading":
                        int emptyCount = 0;

                        //loop as long as we have time or we haven't reach the end of the answer
                        while (DateTime.Now.CompareTo(timeOut) < 0 && emptyCount < 2)
                        {
                            //if there is some data to be read
                            if (stream.DataAvailable)
                            {
                                //read the data
                                byte[] rBuff = new byte[4096];
                                int nByteRead;
                                nByteRead = stream.Read(rBuff, 0, rBuff.Length);
                                dataRead = dataRead.Concat(rBuff.Take(nByteRead).ToArray()).ToArray();
                            }
                            else { emptyCount++; }

                            Thread.Sleep(50);
                        }
                        //Exit
                        status = "TimeOut";
                        if (emptyCount >= 2) ok = true; 
                        break;

                    case "TimeOut":
                        //Exit
                        timeOut = DateTime.Now;
                        break;
                }
                //Wait
                Thread.Sleep(20);
            }
            string message = dataRead.ToString();
            if (dataRead.Count() > 0) result = Jconverter.DeserializeObject<List<int>>(message);
            return result;
        }
        */
    }
}

    