//========================================================================
// FILENAME :   iOSClient.cs
// DESCR.   :   iOS implementation of the server client
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using Smartpool.Application.Model;
using Foundation;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model.iOS
{
	public class iOSClient : IClient
	{
		public iOSClient ()
		{
			
		}

		public string StartClient (string whatToSend) {
			return "Login";
		}
	}
}