using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Data.Entity;

namespace WebAPI.Controllers
{
    public class WebApiController : ApiController
    {
        LostandFoundEntities db = new LostandFoundEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetData()
        {
            List<App_Admin> list = db.App_Admin.ToList();
            return Ok(list);
        }
    }
}
