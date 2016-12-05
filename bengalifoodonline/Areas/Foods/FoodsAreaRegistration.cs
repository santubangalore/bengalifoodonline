using System.Web.Mvc;

namespace BengaliFoodOnline.Areas.Foods
{
    public class FoodsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Foods";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Foods_default",
                "Foods/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
