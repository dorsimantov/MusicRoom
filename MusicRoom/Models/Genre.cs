using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicRoom.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [StringLength(30, ErrorMessage = "עד 30 תווים")]
        [Index(IsUnique = true)]
        [Display(Name = "ז'אנר")]
        public string Name { get; set; }
        [Display(Name = "נגנים")]
        public virtual ICollection<User> Users { get; set; }
        [Display(Name = "הרכבים")]
        public virtual ICollection<Band> Bands { get; set; }
    }
}