using Falcon.Entity;
using Falcon.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FalconSchool.Controllers
{
    public class CommonController : Controller
    {
        private ICommonService commonService;

        public CommonController()
        {
            this.commonService = new CommonService();
        }

        // GET: Common
        public JsonResult SearchPostal(string postalCode)
        {
            var _obj = commonService.GetPostalCodeBySearchKey(postalCode);
            return Json(_obj, JsonRequestBehavior.AllowGet);
        }
    }
}