using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "נגנים")]
        public virtual IList<User> Users { get; set; }
        [Required(ErrorMessage ="שדה חובה")]
        [Display(Name = "שם ההרכב")]
        [StringLength(20, ErrorMessage = "עד 20 תווים")]
        [Index(IsUnique = true)]
        public string BandName { get; set; }
        [Display(Name = "ז'אנרים")]
        public virtual IList<Genre> Genres { get; set; }
        [Display(Name = "כלים")]
        public virtual IList<Instrument> Instruments { get; set; }
    }
}