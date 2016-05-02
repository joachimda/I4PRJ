using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
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
            }
            else if (_dimensions != null)
            {
                _dimensions = dimensions;
            }
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
