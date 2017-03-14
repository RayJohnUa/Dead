using DeadEntity;
using DeadEntity.IRepository;
using DeadProject.AppControllers;
using DeadProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeadProject.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository repository)
        {
            _userRepository = repository;
        }
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(_userRepository.GetAll());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int id)
        {
            return View(_userRepository.GetById(id));
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        [HttpPost]
        public ActionResult Create(UserEntity user)
        {
            bool isEmailExist = _userRepository.IsEmailIsExist(user.Email);
            if (!isEmailExist && ModelState.IsValid)
            {
                try
                {
                    _userRepository.Add(user);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                if(isEmailExist)
                    ViewBag.status = StatusHelper.StatusView(Status.Error, "Email is use alredy!!!");
                if(ModelState.IsValid)
                    ViewBag.status = StatusHelper.StatusView(Status.Error, string.Join(",", ModelState.Values.SelectMany(v => v.Errors)));
                return View();
            }
            
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_userRepository.GetById(id));
        }

        // POST: Admin/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserEntity user)
        {
            bool isEmailExist = _userRepository.IsEmailIsExist(user.Email);
            UserEntity olduser = _userRepository.GetById(id);
            if (isEmailExist || olduser.Email == user.Email)
            {
                try
                {
                    _userRepository.Edit(user);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                if (isEmailExist)
                    ViewBag.status = StatusHelper.StatusView(Status.Error, "Email is use alredy!!!");
                if (ModelState.IsValid)
                    ViewBag.status = StatusHelper.StatusView(Status.Error, string.Join(",", ModelState.Values.SelectMany(v => v.Errors)));
                return View();
            }
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Users/Delete/5
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
