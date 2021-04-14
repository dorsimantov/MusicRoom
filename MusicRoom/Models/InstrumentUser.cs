using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class InstrumentUser
    {
        public int Instrument_Id { get; set; }
        public int User_Id { get; set; }

        public virtual Instrument Instrument { get; set; }
        public virtual User User { get; set; }
    }
}