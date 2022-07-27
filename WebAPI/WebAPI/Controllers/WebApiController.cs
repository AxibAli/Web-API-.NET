using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Data.Entity;
using System.Web.Mvc;

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

        [System.Web.Http.HttpPost]
        public IHttpActionResult  Insert(App_Admin admin)
        {
            db.App_Admin.Add(admin);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id) 
        {
            App_Admin admin = db.App_Admin.Where(x=>x.Admin_ID == id).FirstOrDefault();
            db.App_Admin.Remove(admin);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult admindetails(int id)
        {
            App_Admin data = db.App_Admin.Where(x => x.Admin_ID == id).FirstOrDefault();
            return Ok(data);
        }
    }
}
