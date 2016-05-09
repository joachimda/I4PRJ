//========================================================================
// FILENAME :   IStatView.cs
// DESCR.   :   Interface for stat views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 0.1  LP      Initial version, missing implementation
// 1.0  LP      Added methods for showing data
//========================================================================

// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using Smartpool.Application.Model;

namespace Smartpool.Application.Presentation
{
	public interface IStatView : IView, IPoolDisplaying, IAlertDisplaying
	{
        /// <summary>
        /// Should display the list of sensor types and their associated values
        /// </summary>
        void DisplaySensorData(List<Tuple<SensorType, double>> sensorData);
    }
}