using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Smartpool.Application.Model;

namespace Smartpool.Connection.Client
{

    public class SynchronousSocketClient : IClient
    {

        public string StartClient(string whatToSend)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPAddress ipAddress = IPAddress.Parse("10.240.28.95");
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
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return "Error";
        }

        
    }

}
