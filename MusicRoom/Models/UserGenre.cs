using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class UserGenre
    {
        public int User_Id { get; set; }
        public int Genre_Id { get; set; }

        public virtual User User { get; set; }
        public virtual Genre Genre { get; set; }
    }
}