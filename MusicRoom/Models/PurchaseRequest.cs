using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class PurchaseRequest
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [StringLength(30, ErrorMessage = "עד 30 תווים")]
        [Display(Name = "כותרת")]
        public string Title { get; set; }
        //Why do we need to buy this? filled by requestor
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "צורך")]
        [StringLength(100, ErrorMessage = "עד 100 תווים")]
        public string Need { get; set; }
        //How important is it at the moment? filled by admin 
        [Display(Name = "עדיפות")]
        public string Priority { get; set; }
        //MANUFACTURER product number (P/N)
        [Display(Name = "מק\"ט יצרן")]
        [StringLength(50, ErrorMessage = "עד 50 תווים")]
        public string ProductNumber { get; set; }
        //Admin decides to approve or disapprove the request
        public bool? IsApproved { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [StringLength(20, ErrorMessage = "עד 20 תווים")]
        [Display(Name = "מספר טלפון")]
        public string ContactPhone { get; set; }
        public int RequestorId { get; set; }
        public int AdminId { get; set; }
    }
}