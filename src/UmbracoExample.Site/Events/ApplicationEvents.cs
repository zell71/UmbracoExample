using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using DevTrends.MvcDonutCaching;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Logging;
using Umbraco.Web.Cache;

namespace UmbracoExample.Site.Events
{
    public class ApplicationEvents : ApplicationEventHandler
    {
        /// <summary>
        /// Gets the outputcache manager.
        /// </summary>
        public OutputCacheManager OutputCacheManager => new OutputCacheManager();

        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // Assign events for managing content caching.
            PageCacheRefresher.CacheUpdated += this.PageCacheRefresherCacheUpdated;
            MediaCacheRefresher.CacheUpdated += this.MediaCacheRefresherCacheUpdated;
            MemberCacheRefresher.CacheUpdated += this.MemberCacheRefresherCacheUpdated;
        }

        /// <inheritdoc/>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // Register custom routes.
            RouteBuilder.RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// The page cache refresher cache updated event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CacheRefresherEventArgs"/> containing information about the event.</param>
        private void PageCacheRefresherCacheUpdated(PageCacheRefresher sender, CacheRefresherEventArgs e)
        {
            this.ClearCache();
        }

        /// <summary>
        /// The media cache refresher cache updated event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CacheRefresherEventArgs"/> containing information about the event.</param>
        private void MediaCacheRefresherCacheUpdated(MediaCacheRefresher sender, CacheRefresherEventArgs e)
        {
            this.ClearCache();
        }

        /// <summary>
        /// The media cache refresher cache updated event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CacheRefresherEventArgs"/> containing information about the event.</param>
        private void MemberCacheRefresherCacheUpdated(MemberCacheRefresher sender, CacheRefresherEventArgs e)
        {
            this.ClearCache();
        }

        /// <summary>
        /// Clears the output cache of all items.
        /// </summary>
        private void ClearCache()
        {
            try
            {
                // Remove all caches.
                this.OutputCacheManager.RemoveItems();
                LogHelper.Info<ApplicationEvents>($"Donut Output Cache cleared on Server:{Environment.MachineName} AppDomain:{AppDomain.CurrentDomain.FriendlyName} for all items");
            }
            catch (Exception ex)
            {
                LogHelper.Error<ApplicationEvents>($"Donut Output Cache failed to clear on Server:{Environment.MachineName} AppDomain:{AppDomain.CurrentDomain.FriendlyName}", ex);
            }
        }
    }
}