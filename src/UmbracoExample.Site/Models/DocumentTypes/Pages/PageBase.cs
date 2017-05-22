using Zoombraco.Models;

namespace UmbracoExample.Site.Models
{
    public class PageBase : Page, IHeroPanel
    {
        public virtual Image HeroImage { get; set; }
    }
}