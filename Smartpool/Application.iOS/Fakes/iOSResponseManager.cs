//========================================================================
// FILENAME :   iOSResponseManager.cs
// DESCR.   :   Fake message response generator for iOS socket client
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1	LP		Final version, this is a FAKE client response manager
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
			case TokenSubMessageTypes.GetPoolInfoRequest:
				return ResponseForGetPoolInfoRequest ((GetPoolInfoRequestMsg)message);
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
				pools.Add(new Tuple<string, bool>("Min slemme pool", false));

				return new GetPoolDataResponseMsg (null, pools);
			}
			else
			{
				// Generate readings
				var readings = new List<Tuple<SensorTypes, List<double>>>();
				readings.Add(new Tuple<SensorTypes, List<double>>(SensorTypes.Temperature, new List<double>(){30.7, 31.5, 32.2, 35.2, 35.2, 32.1, 32.0, 30.1, 30.0, 32.1, 32.5, 34.2, 33.2, 36.0, 35.0}));
				readings.Add(new Tuple<SensorTypes, List<double>>(SensorTypes.Humidity, new List<double>(){51, 50, 55, 65, 72, 70, 74, 72, 68, 66, 58, 54, 56, 52, 56}));
				readings.Add(new Tuple<SensorTypes, List<double>>(SensorTypes.Ph, new List<double>(){7.1, 7.0, 7.2, 7.5, 7.3, 7.2, 7.1, 7.0, 7.2, 7.1, 7.0, 6.4, 6.8, 7.0, 7.2}));
				readings.Add(new Tuple<SensorTypes, List<double>>(SensorTypes.Chlorine, new List<double>(){1.8, 1.7, 1.8, 1.6, 1.4, 1.8, 1.8, 1.7, 1.8, 2.2, 1.9, 1.8, 2.2, 1.9, 1.8 }));

				return new GetPoolDataResponseMsg(readings, null);
			}
		}

		private Message ResponseForGetPoolInfoRequest(GetPoolInfoRequestMsg message)
		{
			var serialNumber = "5XXAS-WWWD2-ASCC1-APW2W-98QSS";
			var randomizer = new Random ();
			var volume = randomizer.Next (20, 100);

			return new GetPoolInfoResponseMsg (volume, serialNumber);
		}
	}
}