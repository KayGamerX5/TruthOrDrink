using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    public class Question
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string QuestionBody { get; set; }


        public int Category { get; set; }
                    //<x:String>On the rocks</x:String> 0
                    //<x:String>Happy hour</x:String>   1
                    //<x:String>Last call</x:String>    2    Categories
                    //<x:String>Extra dirty</x:String>  3
    }
}
