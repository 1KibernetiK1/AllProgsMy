using AspAjaxMaterialDesign.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AspAjaxMaterialDesign.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowStudents_V1()
        {
            var studs = Student
                .LoadList()
                .Where(s => s.Group == AcGroup.BI305)
                .ToList();

            return View(studs);
        }

        [HttpPost]
        public ActionResult ShowStudents_V1(string selectedGroup)
        {
            var studs = new List<Student>();

            if (selectedGroup == "All")
            {
                studs = Student.LoadList();
            }
            else
            {
                var group = (AcGroup)
                    Enum.Parse(typeof(AcGroup), selectedGroup);

                studs = Student
                .LoadList()
                .Where(s => s.Group == group)
                .ToList();
            }
            Thread.Sleep(10000);
            return View(studs);
        }
        
        // V2 - request via asp.ajax
        public ActionResult ShowStudents_V2()
        {
            return View((object) "BI305");
        }

        // V3 - request via ajax + jquery
        public ActionResult ShowStudents_V3()
        {
            string[] mass = Enum.GetNames(typeof(AcGroup));
            string jsonGroup = "";
            foreach (var item in mass)
            {
                jsonGroup += $" '{item}', ";
            }
            jsonGroup = jsonGroup.Remove(jsonGroup.Length - 1, 1);
            jsonGroup = "[" + jsonGroup + "]";

            ViewBag.JsonGroup = new MvcHtmlString(jsonGroup);

            return View();
        }

        public string GetStudents_V3(string selectedGroup = "BI305")
        {
            var studs = new List<Student>();

            if (selectedGroup == "All")
            {
                studs = Student.LoadList();
            }
            else
            {
                var group = (AcGroup)
                    Enum.Parse(typeof(AcGroup), selectedGroup);

                studs = Student
                .LoadList()
                .Where(s => s.Group == group)
                .ToList();
            }

            string json = JsonConvert.SerializeObject(studs);

            Thread.Sleep(10000);

            return json;
        }

        // метод для 2й-версии
        public PartialViewResult GetStudents(string selectedGroup= "BI305")
        {
            var studs = new List<Student>();

            if (selectedGroup == "All")
            {
                studs = Student.LoadList();
            }
            else
            {
                var group = (AcGroup)
                    Enum.Parse(typeof(AcGroup), selectedGroup);

                studs = Student
                .LoadList()
                .Where(s => s.Group == group)
                .ToList();
            }
            return PartialView(studs);
        }

    }
}