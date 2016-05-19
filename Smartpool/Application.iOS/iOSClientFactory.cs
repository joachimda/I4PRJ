using System;
using Smartpool.Connection.Model;

namespace Application.iOS
{
	public class iOSClientFactory
	{
		public static string ServerIP = "93.166.226.201";
		
		public static IClientMessenger DefaultClient()
		{
			if (ServerIP == "test")
				return new iOSClientMessenger ();
			else
				return new ClientMessenger (new iOSClient (ServerIP));
		}
	}
}