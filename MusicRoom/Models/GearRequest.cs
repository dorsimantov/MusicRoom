using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class GearRequest
    {
        [Key]
        public int Id { get; set; }
        public int RequestorId { get; set; }
        //Id of admin who approved or disapproved
        public int? AdminId { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "צורך")]
        public string Reason { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "ציוד")]
        public string Gear { get; set; }
        //Where will the gear be taken to
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "לאן")]
        public string Where { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "תחילת ההשאלה")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "סיום ההשאלה")]
        public DateTime EndTime { get; set; }
        //Set by admin
        public bool? IsApproved { get; set; }
    }
}