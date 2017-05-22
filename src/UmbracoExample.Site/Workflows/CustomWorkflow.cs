using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Logging;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;

namespace UmbracoExample.Site.Workflows
{
    public class CustomWorkflow : WorkflowType
    {
        [Umbraco.Forms.Core.Attributes.Setting("Cookie Name")]
        public string CookieName { get; set; }

        [Umbraco.Forms.Core.Attributes.Setting("Cookie Expiry - In days")]
        public string CookieExpiryInDays { get; set; }

        public CustomWorkflow()
        {
            Id = new Guid("7b8e492e-0bf1-471f-a696-d8d8927e7d54");
            Name = "Set cookie workflow";
            Description = "Saves the current form record to a member so the form can be resumed at a later date";
        }

        public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
        {
            var contactId = Guid.NewGuid().ToString();

            if (!string.IsNullOrEmpty(contactId))
            {
                //If successful, take response ID and set in cookie
                try
                {
                    var workflowCookie = new HttpCookie(CookieName);
                    workflowCookie.Value = contactId;
                    workflowCookie.Expires = DateTime.Now.AddDays(double.Parse(CookieExpiryInDays));
                    HttpContext.Current.Response.Cookies.Add(workflowCookie);

                    return WorkflowExecutionStatus.Completed;
                }
                catch (Exception ex)
                {
                    LogHelper.Error<CustomWorkflow>("SetCookieWorkFlow - Failed", ex);
                    return WorkflowExecutionStatus.Failed;
                }
            }
            return WorkflowExecutionStatus.Failed;
        }

        public override List<Exception> ValidateSettings()
        {
            List<Exception> exceptionList = new List<Exception>();
            if (string.IsNullOrEmpty(CookieName))
                exceptionList.Add(new Exception("’CookieName’ setting has not been set"));

            if (string.IsNullOrEmpty(CookieExpiryInDays))
                exceptionList.Add(new Exception("’CookieExpiryInDays’ setting has not been set’"));

            double expiryDays;
            if (!double.TryParse(CookieExpiryInDays, out expiryDays))
                exceptionList.Add(new Exception("’CookieExpiryInDays’ is not a valid day count’"));

            return exceptionList;
        }
    }
}