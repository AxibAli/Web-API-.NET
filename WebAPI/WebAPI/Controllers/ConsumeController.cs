using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ConsumeController : Controller
    {
        HttpClient hc = new HttpClient();

        // GET: Consume
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admins()
        {
            List<App_Admin> list = new List<App_Admin>();

            hc.BaseAddress = new Uri("https://localhost:44360/api/webapi/GetData");
            var consume = hc.GetAsync("GetData");
            consume.Wait();
            var test = consume.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<App_Admin>>();
                list = display.Result;
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult SendData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendData(App_Admin data)
        {
            hc.BaseAddress = new Uri("https://localhost:44360/api/webapi/Insert");
            var consume = hc.PostAsJsonAsync("Insert", data);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Admins");
            }
            else 
            {
                return HttpNotFound();
            }
        }
        public ActionResult delete(int id)
        {
            App_Admin app_Admin = new App_Admin();
            hc.BaseAddress = new Uri("https://localhost:44360/api/webapi/Delete");
            var consume = hc.DeleteAsync("Delete?id=" + id.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Admins");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            App_Admin data = new App_Admin();
            hc.BaseAddress = new Uri("https://localhost:44360/api/webapi/admindetails");
            var consume = hc.GetAsync("admindetails?id=" + id.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<App_Admin>();
                display.Wait();
                data = display.Result;

            }
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            App_Admin appadmin = null;
            hc.BaseAddress = new Uri("https://localhost:44360/api/webapi/admindetails");
            var consume = hc.GetAsync("admindetails?id=" + id.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<App_Admin>();
                display.Wait();
                appadmin=display.Result;
            }
            return View(appadmin);
        }
        [HttpPost]
        public ActionResult Edit(App_Admin data)
        {
            hc.BaseAddress = new Uri("https://localhost:44360/api/webapi/Update");
            var consume = hc.PutAsJsonAsync<App_Admin>("update", data);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Admins");
            }
            return View();
        }
    }
}