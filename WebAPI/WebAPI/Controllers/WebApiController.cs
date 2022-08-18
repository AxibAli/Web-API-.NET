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

        bool result ;

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

        [System.Web.Http.HttpPut]
        public IHttpActionResult Update(App_Admin data) 
        {
            App_Admin ad = db.App_Admin.Where(x => x.Admin_ID == data.Admin_ID).SingleOrDefault();
            ad.Admin_FullName= data.Admin_FullName;
            ad.Admin_Gender= data.Admin_Gender;
            ad.Admin_Email= data.Admin_Email;
            ad.Admin_Contact= data.Admin_Contact;
            ad.Admin_DOB= data.Admin_DOB;
            db.SaveChanges();
            return Ok();
        } 

        [System.Web.Http.HttpPost]
        
        public IHttpActionResult login(LoginModel logindata) 
        {
            try
            {
                var user = db.App_User.Where
                   (x => x.User_Email == logindata.UserName ||
                    x.User_FullName == logindata.UserName &&
                    x.User_Password == logindata.Password && x.User_IsActive != false).FirstOrDefault();

                App_User userdata = null;

                if (user != null)
                {
                    userdata = new App_User()
                    {
                        User_FullName = user.User_FullName,
                        User_ID = user.User_ID,
                        User_Email = user.User_Email,
                        User_Role = user.User_Role,
                        User_Password = user.User_Password,
                        User_IsActive = user.User_IsActive
                        
                    };
                    result = true;
                }
                return Json(userdata);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
