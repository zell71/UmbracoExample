using System.Web;

namespace UmbracoExample.Site.Models
{
    public class GenericPage : PageBase
    {
        public virtual string Title { get; set; }
        public virtual HtmlString ContentBody { get; set; }
    }
}