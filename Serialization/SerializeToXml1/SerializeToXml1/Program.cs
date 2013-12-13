using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeToXml1
{
    class Program
    {
        static void Main(string[] args)
        {
            PoolRepository.DeleteDataFile();
            Pool.CreateNewPool("Team A", "Team B", "test", "balach");
            Pool.CreateSeedDataIfNeeded();
            PoolRepository.WriteDataFile();
        }
    }
}
