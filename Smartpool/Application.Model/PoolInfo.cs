// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public class PoolInfo
    {
        public PoolInfo(double temperature, double clorine)
        {
            Temperature = temperature;
            Clorine = clorine;
        }
        private double _temperature;

        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        private double _chlorine;

        public double Clorine
        {
            get { return _chlorine; }
            set { _chlorine = value; }
        }
    }
}
