using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Models;
using Leave_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Leave_Management.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;
        public LeaveTypeController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
     
        // GET: LeaveType
        public ActionResult Index()
        {
            var leaveType = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveType);
            return View(model);
        }

        // GET: LeaveType/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();//for 404 error to user
            }
            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(model);
        }

        // GET: LeaveType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;
                var isSuccess=_repo.Create(leaveType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Somthing Went Wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Somthing Went Wrong");
                return View(model);
            }
        }

        // GET: LeaveType/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();//for 404 error to user
            }
            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(model);
        }

        // POST: LeaveType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                  var leaveType = _mapper.Map<LeaveType>(model);
                  var success = _repo.Update(leaveType);
                if (!success)
                {
                    ModelState.AddModelError("", "Somthing Went Wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Somthing Went Wrong");
                return View(model);
            }
        }

        // GET: LeaveType/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    if (!_repo.isExists(id))
        //    {
        //        return NotFound();
        //    }
        //    var leaveType = _repo.FindById(id);
        //    var model = _mapper.Map<LeaveTypeVM>(leaveType);
        //    return View(model);
          
        //}
        public ActionResult Delete(int id)
        {
            // TODO: Add delete logic here
            var leaveType = _repo.FindById(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(leaveType);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));

        }

        // POST: LeaveType/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, LeaveTypeVM model)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        var leaveType = _repo.FindById(id);
        //        if (leaveType == null)
        //        {
        //            return NotFound();
        //        }
        //        var isSuccess = _repo.Delete(leaveType);
        //        if (!isSuccess)
        //        {
        //            return View(model);
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View(model);
        //    }
        //}
    }
}