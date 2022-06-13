﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftWeb.ViewComponents
{
    [ViewComponent(Name = "Counter")]
    public class CounterViewComponent : ViewComponent       
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}