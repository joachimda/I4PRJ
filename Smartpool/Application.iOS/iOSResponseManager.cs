//========================================================================
// FILENAME :   iOSResponseManager.cs
// DESCR.   :   Fake message response generator for iOS socket client
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using Smartpool.Connection.Model;

namespace Application.iOS
{
	public class iOSResponseManager
	{
		public Message ResponseForMessage(Message message)
		{
			switch (message.MsgType)
			{
			case MessageTypes.LoginRequest:
				return ResponseForLoginRequestMessage ((LoginRequestMsg)message);
			case MessageTypes.AddUserRequest:
				return ResponseForAddUserRequestMessage ((AddUserRequestMsg)message);
			default:
				return new GeneralResponseMsg (true, true);
			}
		}

		private Message ResponseForLoginRequestMessage(LoginRequestMsg message)
		{
			return new LoginResponseMsg ("tokenString", true);
		}

		private Message ResponseForAddUserRequestMessage(AddUserRequestMsg message)
		{
			return new GeneralResponseMsg (true, true);
		}
	}
}