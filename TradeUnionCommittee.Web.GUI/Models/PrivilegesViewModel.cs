﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.Web.GUI.Models
{
    public class PrivilegesViewModel : DirectoryViewModel
    {
        public override long? Id { get; set; }

        [Required(ErrorMessage = "Назва не може бути порожньою!")]
        [Remote("CheckName", "Privileges", ErrorMessage = "Ця назва вже використовується!")]
        public override string Name { get; set; }
    }
}