using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class InstrumentBand
    {
        public int Instrument_Id { get; set; }
        public int Band_Id { get; set; }
        
        public virtual Instrument Instrument { get; set; }
        public virtual Band Band { get; set; }
    }
}