using System;
using System.IO;
using System.Runtime.Serialization;

namespace SerializeToXml1
{
    public static class PoolRepository
    {
        private static string PoolStoreFile
        {
            get
            {
                return "C:\\temp\\PoolData.xml";
            }
        }

        public static void ReadDataFile()
        {
            if (File.Exists(PoolStoreFile))
            {
                using (var fileStream = new FileStream(PoolStoreFile, FileMode.Open))
                {
                    RestoreFromDatafile(fileStream);
                }
            }
        }

        public static void WriteDataFile()
        {
            if (Pool.Instance != null)
            {
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(PoolStoreFile)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(PoolStoreFile));
                    }
                    using (var fileStream = new FileStream(PoolStoreFile, FileMode.OpenOrCreate))
                    {
                        SaveToDataFile(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    // TODO: Log this properly
                    Console.WriteLine();
                }
            }
        }


        public static void DeleteDataFile()
        {
            Pool.Instance = null;

            if (File.Exists(PoolStoreFile))
            {
                File.Delete(PoolStoreFile);
            }
        }

        #region Serialization
        private static void RestoreFromDatafile(FileStream inFile)
        {
            var serializer = new DataContractSerializer(typeof(Pool));
            Pool.Instance = (Pool)serializer.ReadObject(inFile);
        }

        private static void SaveToDataFile(FileStream outFile)
        {
            //Serialize the app state
            var serializer = new DataContractSerializer(typeof(Pool));

            var g = Pool.Instance;

            var c = new GridCell();
            c.Update("test");

            g.Grid[0][0].Update("change");

            //Your app pool's identity should have write access to this file.
            serializer.WriteObject(outFile, g);
        }
        #endregion
    }
}
