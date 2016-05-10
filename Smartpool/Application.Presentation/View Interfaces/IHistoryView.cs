//========================================================================
// FILENAME :   IHistoryView.cs
// DESCR.   :   Interface for history views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using System.Collections.Generic;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IHistoryView : IView, IPoolDisplaying, IAlertDisplaying
    {
        /// <summary>
        /// Should display the list of sensor types and a list of their associated values
        /// </summary>
        void DisplayHistoricData(List<Tuple<SensorTypes, List<double>>> historicData);
    }
}