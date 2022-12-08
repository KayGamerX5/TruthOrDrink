using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    public class User
    {

        [PrimaryKey, AutoIncrement]
        public int Id {get; set;}

        [MaxLength(20)]
        public string UserName { get; set;}

        public string Password { get; set;}

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }

        public DateTime Birthday { get; set; }
    }
}
