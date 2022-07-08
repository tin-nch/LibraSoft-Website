﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftCMS.ViewComponents
{
    [ViewComponent(Name = "Slider")]
    public class SliderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
