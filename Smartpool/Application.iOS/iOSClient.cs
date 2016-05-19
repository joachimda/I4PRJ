using System;
using System.Net;
using System.Text;
using Smartpool.Connection.Model;
using Newtonsoft.Json;
using SocketLibrary;
using System.Net.Sockets;

namespace Application.iOS
{
	public class iOSClient : IClient
	{
		private readonly string _serverIp;
		private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
		
		public iOSClient (string serverIp)
		{
			_serverIp = serverIp;
		}

		public string StartClient(string whatToSend)
		{
			// Connect to a remote device.
			try
			{
				// Establish the remote endpoint for the socket.
				IPAddress ipAddress = IPAddress.Parse(_serverIp);

				//IPAddress ipAddress = IPAddress.Parse("2.109.10.231");
				IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

				// Create a TCP/IP  socket.
				var sender = new ConnectedSocket(remoteEP); 

				// Connect the socket to the remote endpoint. Catch any errors.
				try
				{
					// Send the data through the socket.
					sender.Send(whatToSend);

					// Receive the response from the remote device.
					var received = "";
					do {
						received += sender.Receive(1024);
					}
					while (sender.AnythingToReceive);

					Console.WriteLine(received);
					return received;

				}
				catch (Exception)
				{
					return JsonConvert.SerializeObject(new LoginResponseMsg("", false) { MessageInfo = "Error - Server did not respond\nMake sure server is started and Emil isn't nearby" }, _jsonSettings);
				}

			}
			catch (Exception)
			{
				return JsonConvert.SerializeObject(new LoginResponseMsg("", false) {MessageInfo = "Error - Server did not respond\nMake sure server is started and Emil isn't nearby"}, _jsonSettings);
			}
		}
	}
}