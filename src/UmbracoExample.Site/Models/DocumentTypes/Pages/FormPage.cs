using System;
using System.Web;
using Our.Umbraco.Ditto;

namespace UmbracoExample.Site.Models
{
    public class FormPage : PageBase
    {
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [UmbracoProperty(DefaultValue = "Title", AltPropertyName = "Name")]
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the content body
        /// </summary>
        public virtual HtmlString ContentBody { get; set; }

        /// <summary>
        /// Gets or sets the form GUID
        /// </summary>
        public virtual Guid FormPicker { get; set; }
    }
}