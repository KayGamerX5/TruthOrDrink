using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    public class Player
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Score { get; set; }

        public int TimesDrink { get; set; }
    }
}
