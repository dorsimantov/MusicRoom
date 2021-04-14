using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicRoom.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; }
    }
}