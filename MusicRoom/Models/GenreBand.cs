using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class GenreBand
    {
        public int Genre_Id { get; set; }
        public int Band_Id { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Band Band { get; set; }
    }
}