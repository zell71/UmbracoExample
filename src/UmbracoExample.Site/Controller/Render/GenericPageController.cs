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
    public class GenericPageController : ZoombracoController
    {
        public ActionResult GenericPage(RenderModel model)
        {
            var page = model.As<GenericPage>();
            RenderPage<GenericPage> viewModel = new RenderPage<GenericPage>(page);

            return this.CurrentTemplate(viewModel);
        }
    }
}