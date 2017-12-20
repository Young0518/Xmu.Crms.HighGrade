using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Xmu.Crms.HighGrade
{
    public class MeController : ApiController
    {
        //GET /me
        [System.Web.Http.Route("api/me")]
        [System.Web.Http.HttpGet]
        public ActionResult GetMe()
        {
            var result = new JsonResult();
            result.Data = new { id = 3486, type = "student", name = "张三", number = "23320152202333", phone = "18911114514", email = "23320152202333@stu.xmu.edu.cn", gender = "male", school = new { id = 32, name = "厦门大学" }, tltle = "", avatar = "/avatar/3486.png" };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        //PUT /me
        [System.Web.Http.Route("api/me")]
        [System.Web.Http.HttpPut]
        public ActionResult PutMe(User user)
        {
            User u = user;
            var result = new JsonResult();
            result.Data = new {};
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return new HttpStatusCodeResult(204);
        }

        //POST /signin
        [System.Web.Http.Route("api/signin")]
        [System.Web.Http.HttpPost]
        public ActionResult PostSignin(User user)
        {
            User u = user;
            var result = new JsonResult();
            result.Data = new { id = 3486, type = "student", name = "张三" };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        //POST /register
        [System.Web.Http.Route("api/register")]
        [System.Web.Http.HttpPost]
        public ActionResult PostRegister(User user)
        {
            User u = user;
            var result = new JsonResult();
            result.Data = new { id = 3486, type = "inbinded", name = "" };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}
