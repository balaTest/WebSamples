using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;

namespace SerializeToXml1
{
    public enum PoolState { NotReady, Open, Locked, Complete }

    public class Pool
    {
        #region Singleton implementation
        private static volatile Pool instance;
        private static object syncObj = new object();

        public static Pool Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObj)
                    {
                        if (instance == null)
                        {
                            PoolRepository.ReadDataFile();
                        }
                    }
                }
                return instance;
            }
            internal set
            {
                instance = value;

                // null check so we don't read this back in during a the WriteDataFile
                if (value != null)
                {
                    // write the new data any time we overwrite the Instance
                    PoolRepository.WriteDataFile();
                }
            }
        }


        #endregion

        // TODO: this should be removed once we have a setup wizard in place.
        public static void CreateSeedDataIfNeeded()
        {
            if (Instance == null)
            {
                lock (syncObj)
                {
                    if (Instance == null)
                    {
                        // TODO: don't hardcode values
                        Instance = new Pool()
                        {
                            AdminAlias = "sample",
                            Description = "My test pool",
                            State = PoolState.Locked,
                            TeamA = "A",
                            TeamB = "B",

                        };
                        Instance.Grid[0][0].Update("Jimmy");
                        Instance.Grid[3][7].Update("Van");
                        Instance.Grid[7][4].Update("Bala");
                        PoolRepository.WriteDataFile();
                    }
                }
            }
        }

        public static void CreateNewPool(string teamA, string teamB, string caption, string ownerName)
        {
            Pool p = new Pool()
            {
                TeamA = teamA,
                TeamB = teamB,
                Description = caption,
                AdminAlias = ownerName
            };

            Pool.Instance = p;
        }

        private Pool()
        {
            Grid = new GridCell[10][];
            for (int i = 0; i < 10; i++)
            {
                Grid[i] = new GridCell[10];
                for (int j = 0; j < 10; j++)
                {
                    Grid[i][j] = new GridCell();
                }
            }
        }

        [Required, Display(Description = "Name of Team A")]
        public string TeamA;

        [Required, Display(Description = "Name of Team B")]
        public string TeamB;

        [Display(Description = "Game date, start and end times, additional comments")]
        public string Description;

        [Display(Description = "Date and time when the pool will be locked")]
        public DateTime LockTime;

        [Display(Description = "Final score of the game for Team A")]
        public int FinalScore_TeamA;

        [Display(Description = "Final score of the game for Team B")]
        public int FinalScore_TeamB;

        //[DataMember]
        public GridCell[][] Grid;

        public PoolState State = PoolState.NotReady;

        [Required, Display(Description = "User alias of pool admin")]
        public string AdminAlias;

    }

    public class GridCell
    {
        // using String.Empty instead of null makes the payload smaller when encoded in JSON
        private string _cellValue = String.Empty;
        public string CellValue
        {
            get { return _cellValue; }

            set
            {
                // TODO: First verify x and y are valid values between 0 and 9

                // TODO : Validate value contains valid chars and size to qualify as an alias

                _cellValue = value;
            }
        }

        private object syncObj = new object();

        public bool Update(string value)
        {
            if (String.IsNullOrEmpty(_cellValue))
            {
                lock (syncObj)
                {
                    if (String.IsNullOrEmpty(_cellValue))
                    {
                        CellValue = value;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
