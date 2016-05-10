using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Smartpool.Connection.Model;
using Newtonsoft.Json;

namespace Smartpool.Connection.Client
{

    public class SynchronousSocketClient : IClient
    {
        private readonly string _serverIp;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public SynchronousSocketClient() { }
        public SynchronousSocketClient(string serverIp)
        {
            _serverIp = serverIp;
        }

        public string StartClient(string whatToSend)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[10240];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPAddress ipAddress = IPAddress.Parse(_serverIp);
                //IPAddress ipAddress = IPAddress.Parse("2.109.10.231");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);
                    
                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes(whatToSend);

                    // Send the data through the socket.
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);

                    var stringReturned = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                    return stringReturned;

                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(new LoginResponseMsg("", false) { MessageInfo = "Error - Server did not respond\nMake sure server is started and Emil isn't nearby" }, _jsonSettings);
                }

            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new LoginResponseMsg("", false) {MessageInfo = "Error - Server did not respond\nMake sure server is started and Emil isn't nearby"}, _jsonSettings);
            }
            return "Error";
        }

        
    }

}
