using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workshop.Core.ViewModel;
using Workshop.Core;
using Workshop.Common;
using Workshop.Core.Technologies;



namespace WorkshopRegistration.Controllers
{
    public class WorkshopController : Controller
    {
        // GET: Workshop
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(WorkshopViewModel WorkshopVM)
        {
           
            WorkshopBL workshopBL = new WorkshopBL();
            try
            {
                workshopBL.WorkshopReg(WorkshopVM);
            }
            catch { }
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetTechnologyList()
        {
            List<TechnologiesViewModel> technologiesList = new List<TechnologiesViewModel>();
            TechnologiesBL technologiesBL = new TechnologiesBL();
            try
            {
                technologiesList = technologiesBL.GetTechnologyList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Json(technologiesList, JsonRequestBehavior.AllowGet);
        }

    }
}