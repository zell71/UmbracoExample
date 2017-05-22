using System.Web.Mvc;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;
using UmbracoExample.Site.Models;
using Zoombraco.Controllers;
using Zoombraco.Models;

namespace UmbracoExample.Site.Controller.Render
{
    public class FormPageController : ZoombracoController
    {
        public ActionResult FormPage(RenderModel model)
        {
            var page = model.As<FormPage>();
            var viewModel = new RenderPage<FormPage>(page);

            return this.CurrentTemplate(viewModel);
        }
    }
}