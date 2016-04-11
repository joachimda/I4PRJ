//========================================================================
// FILENAME :   IClient.cs
// DESCR.   :   Interface for the Smartpool server client
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace

using Smartpool.Connection.Model;

namespace Smartpool.Application.Model
{
	public interface IClientMessager
    {
		/// <summary>
		/// Method for starting a TCP client and sending a string to the server
		/// </summary>
		string SendMessage (string msgType, Message message);
	}
}