using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MusicRoom.Models;

namespace MusicRoom.ViewModels
{
    public class NewBandViewModel
    {
        [Required]
        public Band Band { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<Instrument> Instruments { get; set; }
        public IList<User> Users { get; set; }
    }
}