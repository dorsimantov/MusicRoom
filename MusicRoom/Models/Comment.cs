using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CreatorId { get; set; }
        public DateTime TimeAndDate { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        public string Body { get; set; }
    }
}