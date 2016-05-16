using System;
using Smartpool.Connection.Model;

namespace Application.iOS
{
	public class iOSClientMessenger: IClientMessenger
	{
		// IClientMessenger Interface Implementation

		public Message SendMessage(Message message)
		{
			return iOSResponseManager.ResponseForMessage (message);
		}
	}

	public class iOSResponseManager
	{
		public static Message ResponseForMessage(Message message)
		{
			return new Message ();
		}
	}
}