using System.Web;
using System.Web.Mvc;

namespace jimmy_oidc_test_0402
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
