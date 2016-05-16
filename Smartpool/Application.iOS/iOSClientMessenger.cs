//========================================================================
// FILENAME :   iOSClientMessenger.cs
// DESCR.   :   Messenger for iOS socket client
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 0.1  LP      Initial version, using fake response manager
//========================================================================

using Smartpool.Connection.Model;

namespace Application.iOS
{
	public class iOSClientMessenger: IClientMessenger
	{
		// IClientMessenger Interface Implementation

		public Message SendMessage(Message message)
		{
			var responseManager = new iOSResponseManager ();
			return responseManager.ResponseForMessage (message);
		}
	}
}