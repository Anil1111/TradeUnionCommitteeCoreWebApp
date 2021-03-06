﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TradeUnionCommittee.Web.GUI.AdditionalSettings.Oops
{
    public class Oops : Controller, IOops
    {
        public IActionResult OutPutError(string backController, string backAction, IEnumerable<string> errors)
        {
            ViewData["BackController"] = backController;
            ViewData["BackAction"] = backAction;
            ViewBag.Errors = errors;
            return View("Oops");
        }
    }
}