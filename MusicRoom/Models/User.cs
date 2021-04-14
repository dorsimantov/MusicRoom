using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "שם משתמש")]
        [StringLength(20, ErrorMessage = "עד 20 תווים")]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        //[Required]
        [Display(Name = "שם מלא")]
        public string FullName { get; set; }
        [Display(Name = "תפקיד")]
        public int Role_Id { get; set; } = 1;
        [Display(Name = "התראות במייל")]
        public bool MailSubscription { get; set; } = true;
        [Display(Name = "כלים")]
        public virtual ICollection<Instrument> Instruments { get; set; }
        [Display(Name = "ז'אנרים")]
        public virtual ICollection<Genre> Genres { get; set; }
        [Display(Name = "הרכבים")]
        public virtual ICollection<Band> Bands { get; set; }
    }
}