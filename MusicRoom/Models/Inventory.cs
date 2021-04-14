using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicRoom.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "תיאור")]
        public string Description { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [StringLength(50, ErrorMessage = "עד 50 תווים")]
        [Index(IsUnique = true)]
        [Display(Name = "מק\"ט יצרן")]
        public string ProductNumber { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [StringLength(20, ErrorMessage = "עד 20 תווים")]
        [Index(IsUnique = true)]
        [Display(Name = "מק\"ט יחידה")]
        public string CatalogNumber { get; set; }
        [Display(Name = "מספר סריאלי")]
        [StringLength(50, ErrorMessage = "עד 50 תווים")]
        [Index(IsUnique = true)]
        public string SerialNumber { get; set; }
        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "כמות")]
        public int Quantity { get; set; }
    }
}