using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class Instrument
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [StringLength(20, ErrorMessage = "עד 20 תווים")]
        [Index(IsUnique = true)]
        [Display(Name = "כלי")]
        public string Name { get; set; }
        [Display(Name = "נגנים")]
        public virtual ICollection<User> Users { get; set; }
        [Display(Name = "הרכבים")]
        public virtual ICollection<Band> Bands { get; set; }
    }
}