﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeUnionCommittee.BLL.DTO;
using TradeUnionCommittee.BLL.Interfaces.Directory;
using TradeUnionCommittee.Web.GUI.AdditionalSettings.Oops;
using TradeUnionCommittee.Web.GUI.Models;

namespace TradeUnionCommittee.Web.GUI.Controllers.Directory
{
    public class DormitoryController : Controller
    {
        private readonly IDormitoryService _services;
        private readonly IOops _oops;
        private readonly IMapper _mapper;

        public DormitoryController(IDormitoryService services, IOops oops, IMapper mapper)
        {
            _services = services;
            _oops = oops;
            _mapper = mapper;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        [Authorize(Roles = "Admin,Accountant")]
        public async Task<IActionResult> Index()
        {
            var result = await _services.GetAllAsync();
            return View(result.Result);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        [Authorize(Roles = "Admin,Accountant")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Accountant")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DormitoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _services.CreateAsync(_mapper.Map<DormitoryDTO>(vm));
                return result.IsValid
                    ? RedirectToAction("Index")
                    : _oops.OutPutError("Dormitory", "Index", result.ErrorsList);
            }
            return View(vm);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        [Authorize(Roles = "Admin,Accountant")]
        public async Task<IActionResult> Update(string id)
        {
            if (id == null) return NotFound();
            var result = await _services.GetAsync(id);
            return result.IsValid
                ? View(_mapper.Map<DormitoryViewModel>(result.Result))
                : _oops.OutPutError("Dormitory", "Index", result.ErrorsList);
        }

        [HttpPost, ActionName("Update")]
        [Authorize(Roles = "Admin,Accountant")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateConfirmed(DormitoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.HashId == null) return NotFound();
                var result = await _services.UpdateAsync(_mapper.Map<DormitoryDTO>(vm));
                return result.IsValid
                    ? RedirectToAction("Index")
                    : _oops.OutPutError("Dormitory", "Index", result.ErrorsList);
            }
            return View(vm);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            var result = await _services.GetAsync(id);
            return result.IsValid
                ? View(result.Result)
                : _oops.OutPutError("Dormitory", "Index", result.ErrorsList);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null) return NotFound();
            var result = await _services.DeleteAsync(id);
            return result.IsValid
                ? RedirectToAction("Index")
                : _oops.OutPutError("Dormitory", "Index", result.ErrorsList);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        protected override void Dispose(bool disposing)
        {
            _services.Dispose();
            base.Dispose(disposing);
        }
    }
}