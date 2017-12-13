using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvc.Models;

namespace TestMvc.Controllers
{
    public class StudentController : Controller
    {
        StudentContext ctx;
        public StudentController()
        {
            ctx = new StudentContext();
        }
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            var stulist = ctx.Students.ToList();
            var stumodellist = new List<StudentModel>();
            foreach (var s in stulist)
            {
                var item = new StudentModel() { StudentName = s.StudentName, Year = s.Year, Id = s.Id };
                item.StandardId = ctx.Standards.Where(x => x.Id == s.StandardId).Select(st => st.StandardName).FirstOrDefault();
                item.BatchId = ctx.Batches.Where(x => x.Id == s.BatchId).Select(st => st.BatchName).FirstOrDefault();
                stumodellist.Add(item);
            }
            return View(stumodellist);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            var studentModel = new StudentModel();
            var stdlist = ctx.Standards.ToList();
            var btlist = ctx.Batches.ToList();
            foreach (var std in stdlist)
            {
                var item = new SelectListItem { Text = std.StandardName, Value = std.Id.ToString() };
                studentModel.standardList.Add(item);
            }
            foreach (var bt in btlist)
            {
                var item = new SelectListItem { Text = bt.BatchName, Value = bt.Id.ToString() };
                studentModel.batchList.Add(item);
            }
            return View(studentModel);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentModel stu)
        {
            var st = new Student();
            st.StudentName = stu.StudentName;
            st.Year = stu.Year;
            st.StandardId = int.Parse(stu.StandardId);
            st.BatchId = int.Parse(stu.BatchId);
            ctx.Students.Add(st);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var stu = ctx.Students.Where(x => x.Id == id).FirstOrDefault();
            ctx.Students.Remove(stu);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddStandard()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddStandard(Standard std)
        {
            ctx.Standards.Add(std);
            ctx.SaveChanges();
            return RedirectToAction("StandardList");
        }
        public ActionResult StandardList()
        {
            var list = ctx.Standards.ToList();
            return View(list);
        }

        public ActionResult DeleteStandard(int id)
        {
            var std = ctx.Standards.Where(x => x.Id == id).FirstOrDefault();
            ctx.Standards.Remove(std);
            ctx.SaveChanges();
            return RedirectToAction("StandardList");
        }

        [HttpGet]
        public ActionResult AddBatch()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddBatch(Batch bt)
        {
            ctx.Batches.Add(bt);
            ctx.SaveChanges();
            return RedirectToAction("BatchList");
        }
        public ActionResult BatchList()
        {
            var list = ctx.Batches.ToList();
            return View(list);
        }
        public ActionResult DeleteBatch(int id)
        {
            var bt = ctx.Batches.Where(x => x.Id == id).FirstOrDefault();
            ctx.Batches.Remove(bt);
            ctx.SaveChanges();
            return RedirectToAction("BatchList");
        }

        [HttpGet]
        public ActionResult SearchList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchList(string StuName, string BatchName, string StdName)
        {
            Standard std=new Standard();
            Batch bt=new Batch();
            int i = 0,j=0;
            var stlist = new List<StudentModel>();
            var list = new List<Student>();
            if (!string.IsNullOrEmpty(StuName))
            {
                i++; j++;
            }
            if(!string.IsNullOrEmpty(BatchName))
            {
                bt=ctx.Batches.Where(s => s.BatchName == BatchName ).FirstOrDefault();
                if (bt != null)
                {
                    i++;
                }
                    
            }
            if(!string.IsNullOrEmpty(StdName))
            {
                std=ctx.Standards.Where(s => s.StandardName.Contains(StdName)).FirstOrDefault();
                if (std != null)
                {
                    j++;
                }
                    
            }
            if( i>1 && j >1)
            {
                list = ctx.Students.Where(s => s.StudentName == StuName && s.StandardId == std.Id && s.BatchId == bt.Id).ToList();
            }
            else if(i==2 && j==1)
            {
                list = ctx.Students.Where(s => s.StudentName == StuName && s.BatchId == bt.Id).ToList();
            }
            else if(i==1 && j==2)
            {
                list = ctx.Students.Where(s => s.StudentName == StuName && s.StandardId == std.Id).ToList();
            }
            else if(i==1 && j==1)
            {
                list = ctx.Students.Where(s => s.StudentName == StuName).ToList();
            }
            else if(i==0 && j==1)
            {
                list = ctx.Students.Where(s => s.StandardId == std.Id).ToList();
            }
            else if (i==1 && j == 0)
            {
                list = ctx.Students.Where(s => s.BatchId == bt.Id).ToList();
            }
            if(list!=null)
            {
                foreach (var s in list)
                {
                    var item = new StudentModel() { StudentName = s.StudentName, Year = s.Year, Id = s.Id };
                    item.StandardId = ctx.Standards.Where(x => x.Id == s.StandardId).Select(st => st.StandardName).FirstOrDefault();
                    item.BatchId = ctx.Batches.Where(x => x.Id == s.BatchId).Select(st => st.BatchName).FirstOrDefault();
                    stlist.Add(item);
                }
            }
            return View(stlist);
        }

    }
}