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

        public ActionResult GetConfig(string mode = "get", bool success = true)
        {
            var model = masterService.GetClassConfiguration();

            if (mode == "get" && !success)
            {
                ViewBag.Action = "get";
                ViewBag.AlertShow = true;
                ViewBag.AlertMessage = "Invalid operation !!!";
                ViewBag.AlertClass = "alert alert-warning alert-dismissible fade show";
                ViewBag.Success = false;
            }
            else if (mode == "update" && success)
            {
                ViewBag.Action = "update";
                ViewBag.Success = true;
                ViewBag.AlertShow = true;
                ViewBag.AlertMessage = "Successfully updated classes configuration";
                ViewBag.AlertClass = "alert alert-success alert-dismissible fade show";
            }
            else if (mode == "update" && !success)
            {
                ViewBag.Action = "update";
                ViewBag.Success = false;
                ViewBag.AlertShow = true;
                ViewBag.AlertMessage = "Error while saving configuration";
                ViewBag.AlertClass = "alert alert-danger alert-dismissible fade show";
                ViewBag.Message = "Error while saving configuration";
            }
            else
            {
                ViewBag.AlertShow = false;
                ViewBag.Message = "";
            }

            return View("~/Views/Master/ClassConfig.cshtml", model);
        }

        // POST: ProspectStudent/Create
        [HttpPost]
        public ActionResult UpdateConfig(FormCollection collection)
        {
            var str = collection.AllKeys.Skip(1).ToArray();

            if (str.Where(x => x.Substring(0,1) == "0").Count() > 0)
            {
                if (masterService.UpdateClassConfig(collection.AllKeys.Skip(1).ToArray()))
                {
                    return RedirectToAction("GetConfig", new { mode = "update", success = true });
                }
                else
                {
                    return RedirectToAction("GetConfig", new { mode = "update", success = false });
                }
            }
            else
            {
                return RedirectToAction("GetConfig", new { mode = "get", success = false });
            }
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
