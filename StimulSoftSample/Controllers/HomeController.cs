using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using StimulSoftSample.Models;

namespace StimulSoftSample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FromLoadFileReport()
        {
            PersonModel std = new PersonModel();
            StiReport report = new StiReport();
            List<PersonModel> lst = new List<PersonModel>();
            // دریافت لیست از دیتا بیس
            lst.Add(new PersonModel() { LastName = "Ali", Name = "Ahmadi", Id = 1 });
            lst.Add(new PersonModel() { LastName = "Sara", Name = "Rezayee", Id = 2 });
            lst.Add(new PersonModel() { LastName = "Mohammad", Name = "Hosseini", Id = 3 });
            lst.Add(new PersonModel() { LastName = "Sajjad", Name = "Rezvani", Id = 4 });
            lst.Add(new PersonModel() { LastName = "Maryam", Name = "Akbari", Id = 5 });
            lst.Add(new PersonModel() { LastName = "Pooriya", Name = "Momeni", Id = 6 });
            string Path = Server.MapPath("~/Report/TestReport.mrt");  // نام و مسیر قالبی که در دیزانر ایجاد کردیم
            report.Load(Path);
            report.RegBusinessObject("TestObject", lst); // نام شیئی که در دیزانر ایجاد کردیم
            report.Dictionary.SynchronizeBusinessObjects(2);

            return StiMvcViewer.GetReportSnapshotResult(HttpContext, report);
        }

        //ایجاد پرینت
        public ActionResult PrintReport()
        {
            return StiMvcViewer.PrintReportResult(this.HttpContext);
        }
        //ایجاد خروجی
        public ActionResult ExportReport()
        {
            return StiMvcViewer.ExportReportResult(this.HttpContext);
        }

        public ActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult(this.HttpContext);
        }
    }
}