using DBAccessV1;

namespace DDBAccessV1
{
    public class Pool : IPoolRead, IPoolWrite
    {
        #region Properties

        public string Name { get; set; }

        public int Temperature { get; set; }

        public double Ph { get; set; }

        public double Clorine { get; set; }

        #endregion

        public Pool(string name)
        {
            Name = name;
        }
    }
}