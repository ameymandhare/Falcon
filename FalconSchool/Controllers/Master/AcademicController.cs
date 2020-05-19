using Falcon.Service.MasterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FalconSchool.Controllers.Master
{
    public class AcademicController : Controller
    {
        private readonly IMasterService masterService;

        public AcademicController(IMasterService service)
        {
            this.masterService = service;
        }

        public ActionResult Get()
        {
            throw new NotImplementedException();
        }

        public ActionResult GetConfig()
        {
            var model = masterService.GetClassConfiguration();

            return View("~/Views/Master/ClassConfig.cshtml", model);
        }

        // POST: ProspectStudent/Create
        [HttpPost]
        public ActionResult UpdateConfig(FormCollection collection)
        {
            masterService.UpdateClassConfig(collection.AllKeys.Skip(1).ToArray());
            return RedirectToAction("GetConfig");
        }

        [HttpPost]
        public ActionResult CreateSession()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditSession()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult DeleteSession()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult CreateClass()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditClass()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult DeleteClass()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult CreateSection()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditSection()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult DeleteSection()
        {
            throw new NotImplementedException();
        }
    }

}
