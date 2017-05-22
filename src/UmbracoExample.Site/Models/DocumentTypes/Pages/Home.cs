using System.Web;

namespace UmbracoExample.Site.Models
{
    public class Home : PageBase
    {
        public virtual string Title { get; set; }
        public virtual HtmlString ContentBody { get; set; }
    }
}