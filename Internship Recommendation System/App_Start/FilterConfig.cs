﻿using System.Web;
using System.Web.Mvc;

namespace Internship_Recommendation_System
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
