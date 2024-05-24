using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2
{
    [Table("User")]
    public class User
    {
        // Id, Name, Surname, Birthday, Password, Gender
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID_us { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        // public string Password { get; set; }
        public string Gender { get; set; }
        public int IdGender { get; set; }

    }
}
