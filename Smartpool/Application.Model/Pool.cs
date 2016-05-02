//========================================================================
// FILENAME :   Pool.cs
// DESCR.   :   Pool model
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public class Pool
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public double Volume => ParsedVolume();

        private string _volume;
        private string[] _dimensions = {"", "", ""};

        public void UpdateVolume(string volume, string[] dimensions)
        {
            if (volume != null)
            {
                _volume = volume;
                _dimensions[0] = "";
                _dimensions[1] = "";
                _dimensions[2] = "";
            }
            else if (_dimensions != null)
            {
                _dimensions = dimensions;
                _volume = "";
            }
        }

        public bool IsValid()
        {
            // Returns true if a pool name and serial number is specified
            if (Name.Length == 0) return false;
            if (SerialNumber.Length == 0) return false;
            return true;
        }

        private double ParsedVolume()
        {
            if (_volume != "")
            {
                // Calculating based on volume input so dimensions are redundant
                _dimensions[0] = "";
                _dimensions[1] = "";
                _dimensions[2] = "";

                // Try parsing the input string, otherwise set to 0
                try
                {
                    return double.Parse(_volume);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            else
            {
                // Calculating based on dimensions input so volume is redundant
                _volume = "";

                // Try parsing the input string, otherwise set to 0
                try
                {
                    return double.Parse(_dimensions[0]) * double.Parse(_dimensions[1]) * double.Parse(_dimensions[2]);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}
