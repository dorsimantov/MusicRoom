using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class UserBand
    {
        public int User_Id { get; set; }
        public int Band_Id { get; set; }

        public virtual User User { get; set; }
        public virtual Band Band { get; set; }
    }
}