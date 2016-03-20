using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaasContUni1.DAL;
using HaasContUni1.ViewModels;

namespace HaasContUni1.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
       // {
           // ViewBag.Message = "Your application description page.";

           // return View();
       // }

        public ActionResult About()
        {
            //commented out in Lab 12
            //IQueryable<EnrollmentDateGroup> data = from student in db.Students
            //                                       group student by student.EnrollmentDate into dateGroup
            //                                       select new EnrollmentDateGroup()
            //                                       {
            //                                           EnrollmentDate = dateGroup.Key,
            //                                           StudentCount = dateGroup.Count()
            //                                       };

            // SQL version of the above LINQ code.
            string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
                + "FROM Person "
                + "WHERE Discriminator = 'Student' "
                + "GROUP BY EnrollmentDate";
            IEnumerable<EnrollmentDateGroup> data = db.Database.SqlQuery<EnrollmentDateGroup>(query);

            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}