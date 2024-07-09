using InterviewWork.Models;
using InterviewWork.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewWork.UI.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        // GET: Task
        public ActionResult Index(int profileId)
        {
            ViewBag.ProfileId = profileId;
            var tasks = _taskService.GetTasks(profileId);
            return View(tasks);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create(int profileId)
        {
            ViewBag.ProfileId = profileId;
            return View();

        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskService.TaskAdding(model);
                    return RedirectToAction("Index", new { profileId = model.ProfileId });
                }
                ViewBag.ProfileId = model.ProfileId;
                return View(model);
            }
            catch (Exception Ex)
            {
                TempData["ErrorMessage"] = Ex.Message;
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {

            var task = _taskService.getTaskByID(id);
            if (task == null)
            {
                TempData["InfoMessage"] = "Task Not Found";
                return RedirectToAction("Index");
            }
            // ViewBag.ProfileId = task.ProfileId;
            return View(task);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(TaskModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskService.UpdatingTask(model);
                    return RedirectToAction("Index", new { profileId = model.ProfileId });
                }
                ViewBag.ProfileId = model.ProfileId;
                return View(model);


            }
            catch (Exception Ex)
            {
                TempData["ErrorMessage"] = Ex.Message;
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            var taskmodel = _taskService.getTaskByID(id);
            if (taskmodel == null)
            {
                TempData["InfoMessage"] = "Task Not Found";
                return RedirectToAction("Index", new { profileId = taskmodel.ProfileId });
            }
            return View(taskmodel);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                var taskmodel = _taskService.getTaskByID(id);
                _taskService.DeleteTask(id);
                return RedirectToAction("Index", new { profileId = taskmodel.ProfileId });

            }
            catch (Exception Ex)
            {
                TempData["ErrorMessage"] = Ex.Message;
                return View();
            }
        }
    }
}
