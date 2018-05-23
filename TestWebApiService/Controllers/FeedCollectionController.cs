using BusinessLogicLayer;
using BusinessLogicLayer.SubSystemInterfaces;
using Entities;
using Ninject;
using NinjectConfigurationModule;
using RssLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TestWebApiService.Controllers
{
    //[Authorize]
    public class FeedCollectionController : ApiController
    {
        ISystemFacade system;
        IKernel kernel;
        public FeedCollectionController()
        {
            kernel = new StandardKernel(new NinjectConfig());
            system = new SystemFacade(kernel.Get<IEditSubSystem>(), kernel.Get<IPresentSubSystem>(), kernel.Get<ILoggingSubSystem>());
        }



        [Route("api/feed")]
        public int Post()
        {
            return system.Create();
        }

       
       
        [Route("api/feed/{id}/news")]
        public IHttpActionResult Get(int id)
        {
            var result = Request.CreateResponse(HttpStatusCode.OK,
                                       system.ReadNews(id),
                                       Configuration.Formatters.XmlFormatter);
            result.Headers.Add("Access-Control-Allow-Origin", "*");
            return ResponseMessage(result);

        }

   
        [HttpPost]
        [Route("api/feed/{id}/{name}")]
        public bool Post(int id, string name, [FromBody]string data)
        {
            return system.AddFeed(id, name, data);
           
        }
        

    }
}
