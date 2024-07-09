using InterviewWork.Models;
using InterviewWork.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewWork.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService= profileService;
        }
               // GET: Profile
        public ActionResult Index()
        {
            var ProfileList = _profileService.GetAll();
            return View(ProfileList);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(Profile model)
        {
            try
            {
                bool isInserted = false;
                if (ModelState.IsValid)
                {
                    isInserted = _profileService.InsertProfile(model);
                    if (isInserted)
                    {
                        TempData["SuccessMessage"] = "Saved successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                TempData["ErrorMessage"] = Ex.Message;
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            var _profile = _profileService.getProfileByID(id);
            if (_profile == null)
            {
                TempData["InfoMessage"] = "Profile Not Found";
                return RedirectToAction("Index");
            }
            return View(_profile);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(Profile model)
        {
            try
            {
                bool isUpdated = false;
                if (ModelState.IsValid)
                {
                    isUpdated = _profileService.UpdateProfile(model);
                    if (isUpdated)
                    {
                        TempData["SuccessMessage"] = "Updated Successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to update";
                    }
                }
                return RedirectToAction("Index");

            }
            catch (Exception Ex)
            {
                TempData["ErrorMessage"] = Ex.Message;
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var _profile = _profileService.getProfileByID(id);
                if (_profile == null)
                {
                    TempData["InfoMessage"] = "Product Not Available";
                    return RedirectToAction("Index");
                }
                return View(_profile);
            }
            catch (Exception Ex)
            {
                TempData["ErrorMessage"] = Ex.Message;
                return View();
            }
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                _profileService.DeleteProfile(id);
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                TempData["ErrorMessage"] = Ex.Message;
                return View();
            }
        }
    }
}
