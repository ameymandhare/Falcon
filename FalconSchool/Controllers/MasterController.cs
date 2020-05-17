using Falcon.Service.MasterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FalconSchool.Controllers
{
    public class MasterController : Controller
    {
        private readonly IMasterService masterService;

        public MasterController(IMasterService service)
        {
            this.masterService = service;
        }

        // GET: 
        public ActionResult ClassConfiguration()
        {
            var model = masterService.GetClassConfiguration();

            return View("DivisionConfiguration", model);
        }
    }
}
