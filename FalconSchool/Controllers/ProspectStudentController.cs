using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Constants;
using Falcon.Service.Prospect;
using FalconSchool.Caching;

namespace FalconSchool.Controllers
{
    public class ProspectStudentController : Controller
    {

        private readonly IProspectStudentService prospectService;

        public ProspectStudentController(IProspectStudentService service)
        {
            this.prospectService = service;
        }

        // GET: ProspectStudent
        public ActionResult List()
        {
            var model = prospectService.GetProspectStudentList();

            return View(model);
        }

        // GET: ProspectStudent/Details/5
        public ActionResult Details(int id)
        {
            var model = prospectService.GetProspectStudentDetailsById(id);

            return View("Details",model);
        }

        // GET: ProspectStudent/Create
        public ActionResult Create()
        {
            ViewBag.BloodGrpMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.BloodGrpMaster);
            ViewBag.AdmStatusMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.AdmStatusMaster);
            ViewBag.ReligionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.ReligionMaster);
            ViewBag.CasteMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.CasteMaster);
            ViewBag.CategoryMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.CategoryMaster);
            ViewBag.SessionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.SessionMaster);
            ViewBag.ClassMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.ClassMaster);
            ViewBag.SectionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.SectionMaster);
            ViewBag.GenderMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.GenderMaster);

            return View();
        }

        // POST: ProspectStudent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProspectStudent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProspectStudent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProspectStudent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProspectStudent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
