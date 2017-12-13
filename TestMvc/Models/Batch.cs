using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMvc.Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        public string BatchName { get; set; }
    }
}