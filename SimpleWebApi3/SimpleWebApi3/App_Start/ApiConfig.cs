using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SimpleWebApi3
{
    public class ApiConfig
    {
        public static void ConfigureApi(HttpConfiguration config)
        {
            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }

    }
}