//========================================================================
// FILENAME :   IPoolDisplaying.cs
// DESCR.   :   Interface for displayers of pool information (with tab bar)
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IPoolDisplaying
    {
        /// <summary>
        /// Sets the list of available pools (tuples with name and notification status)
        /// </summary>
        void SetAvailablePools(List<Tuple<string, bool>> pools);
    }
}
