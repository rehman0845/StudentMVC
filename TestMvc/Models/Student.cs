using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestMvc.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int StandardId { get; set; }
        public int BatchId { get; set; }
        public string Year { get; set; }
        public virtual Standard Standard { get; set; }
        public virtual Batch Batch { get; set; }

    }

    public class StudentModel
    {
        public StudentModel()
        {
            standardList = new List<SelectListItem>();
            batchList = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string StudentName { get; set; }

        [Display(Name="StandardName ")]
        public string StandardId { get; set; }

        [Display(Name = "BatchName ")]
        public string BatchId { get; set; }
        public string Year { get; set; }
        public IList<SelectListItem> standardList { get; set; }
        public IList<SelectListItem> batchList { get; set; }
    }
} 