using System;
//========================================================================
// FILENAME :   SensorTypes.cs
// DESCR.   :   Enum with supported sensor types
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public enum SensorType
    {
        Temperature,
        Ph,
        Chlorine,
        Humidity
    }
}
