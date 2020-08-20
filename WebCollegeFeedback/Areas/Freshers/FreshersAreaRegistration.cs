using System.Web.Mvc;

namespace WebCollegeFeedback.Areas.Freshers
{
    public class FreshersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Freshers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Freshers_default",
                "Freshers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebCollegeFeedback.Areas.Freshers.Controllers" }
            );
        }
    }
}