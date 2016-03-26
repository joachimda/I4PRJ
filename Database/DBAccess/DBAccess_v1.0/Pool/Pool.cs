using DBAccessV1;

namespace DDBAccessV1
{
    public class Pool : IPoolRead, IPoolWrite
    {
        public string Name { get; set; }

        public Pool(string name)
        {
            Name = name;
        }
    }
}