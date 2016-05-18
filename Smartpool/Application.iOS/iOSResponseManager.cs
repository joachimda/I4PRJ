﻿//========================================================================
// FILENAME :   iOSResponseManager.cs
// DESCR.   :   Fake message response generator for iOS socket client
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using Smartpool.Connection.Model;
using System;
using System.Collections.Generic;

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
			case MessageTypes.TokenMsg:
				return ResponseForTokenMessage ((TokenMsg)message);	
			default:
				return new GeneralResponseMsg (true, true);
			}
		}

		// Non-Token Messages

		private Message ResponseForLoginRequestMessage(LoginRequestMsg message)
		{
			return new LoginResponseMsg ("tokenString", true);
		}

		// Token Messages

		private Message ResponseForTokenMessage(TokenMsg message)
		{
			switch (message.SubMsgType)
			{
			case TokenSubMessageTypes.GetPoolDataRequest:
				return ResponseForGetPoolDataRequest ((GetPoolDataRequestMsg)message);
			default:
				return new GeneralResponseMsg (true, true);
			}
		}

		private Message ResponseForGetPoolDataRequest(GetPoolDataRequestMsg message)
		{
			if (message.GetAllNamesOnly)
			{
				// Generate pools
				var pools = new List<Tuple<string, bool>> ();
				pools.Add(new Tuple<string, bool>("Min sjove pool", false));
				pools.Add(new Tuple<string, bool>("Lasses pool", false));

				return new GetPoolDataResponseMsg (null, pools);
			}
			else
			{
				// Generate readings
				var readings = new List<Tuple<SensorTypes, List<double>>>();
				readings.Add(new Tuple<SensorTypes, List<double>>(SensorTypes.Temperature, new List<double>(){30.7, 31.5, 32.2}));
				readings.Add(new Tuple<SensorTypes, List<double>>(SensorTypes.Humidity, new List<double>(){51, 50, 55}));
				readings.Add(new Tuple<SensorTypes, List<double>>(SensorTypes.Ph, new List<double>(){7.1, 7.0, 7.2}));
				readings.Add(new Tuple<SensorTypes, List<double>>(SensorTypes.Chlorine, new List<double>(){1.8, 1.7, 1.8}));

				return new GetPoolDataResponseMsg(readings, null);
			}
		}
	}
}