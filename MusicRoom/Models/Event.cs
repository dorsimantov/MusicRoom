using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "כותרת")]
        public string Title { get; set; }
        [Display(Name = "מועד")]
        public DateTime TimeAndDate { get; set; }
        public string Body { get; set; }
        public int CreatorId { get; set; }
    }
}