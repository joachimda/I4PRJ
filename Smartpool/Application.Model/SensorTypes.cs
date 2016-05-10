using System;
//========================================================================
// FILENAME :   SensorTypes.cs
// DESCR.   :   Enumeration of supported sensor types
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public enum SensorTypes
    {
        Temperature, // Leisure waters	28ºC to 30ºC http://pwtag.org/technicalnotes/pool-temperatures/
        Ph, // The guideline pH figure is 7.2 – 7.6 http://www.pahlen.com/users-guide/ph-and-chlorine
        Chlorine, // 0.5-1.5 ppm (mg/l) http://www.pahlen.com/users-guide/ph-and-chlorine
        Humidity // Maintain Relative Humidity between 50% & 60% RH. Do not go below 50% http://www.serescodehumidifiers.com/engineers/indoor-pool-design/Attic/comfort-health-safety.html
    }
}
