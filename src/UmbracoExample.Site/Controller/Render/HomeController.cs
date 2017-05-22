using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;
using UmbracoExample.Site.Models;
using Zoombraco.Controllers;
using Zoombraco.Models;

namespace UmbracoExample.Site.Controller.Render
{
    public class HomeController : ZoombracoController
    {       
        public ActionResult Home(RenderModel model)
        {
            var page = model.As<Home>();
            RenderPage<Home> viewModel = new RenderPage<Home>(page);

            return this.CurrentTemplate(viewModel);
        }
    }
}