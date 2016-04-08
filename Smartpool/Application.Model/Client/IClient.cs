//========================================================================
// FILENAME :   IClient.cs
// DESCR.   :   Interface for the Smartpool server client
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
	public interface IClient
	{
		/// <summary>
		/// Method for starting a TCP client and sending a string to the server
		/// </summary>
		string StartClient (string whatToSend);
	}
}