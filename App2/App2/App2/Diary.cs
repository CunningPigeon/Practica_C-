using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    [Table("Diary")]
    public class Diary
    {
        
        [PrimaryKey, AutoIncrement, Column("_id")] //, Column("_id")
        public int ID { get; set; }
        public int id_us { get; set; }
        public double Sugar { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Feeling { get; set; } // самочувствие
        public int idFeeling { get; set; }
        public string When { get; set; } // подробности
        public int idWhen { get; set; }
        public string Note { get; set; }
    }
}
