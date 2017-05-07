using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;
using SampleService.WebApi.Notes;

namespace SampleService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Mapper.Initialize(cfg =>
            {
                NotesController.SetupMapper(cfg);
            });
        }
    }
}
