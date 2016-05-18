using System.Collections.Generic;
using Smartpool.Connection.Model;

namespace Application.iOS
{
	public class GuiCharacter
	{
		public static string SignForType(SensorTypes type)
		{
			switch (type)
			{
			case SensorTypes.Temperature:
				return "°C";
			case SensorTypes.Humidity:
				return "%";
			case SensorTypes.Chlorine:
				return "ppm";
			default:
				return "";
			}
		}
	}
}