using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMvc.Models
{
    public class Standard
    {
        [Key]
        public int Id { get; set; }
        public string StandardName { get; set; }
    }
}