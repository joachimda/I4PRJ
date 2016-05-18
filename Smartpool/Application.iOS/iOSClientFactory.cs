using System;
using Smartpool.Connection.Model;

namespace Application.iOS
{
	public class iOSClientFactory
	{
		public static IClientMessenger DefaultClient()
		{
			return new ClientMessenger (new iOSClient ("93.166.226.201"));
		}
	}
}