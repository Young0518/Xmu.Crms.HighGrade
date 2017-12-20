
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Xmu.Crms.HighGrade
{
    public class CourseController : ApiController
    {
        // GET /course
        [System.Web.Http.Route("api/course")]
        [System.Web.Http.HttpGet]
        public ActionResult GetCourseList()
        {
            var result = new JsonResult();
            var data = new object[]{
                new {
                    id = 1,
                    name = "OOAD",
                    numClass = 3,
                    numStudent = 60,
                    teacherName="邱明",
                    startTime = "2017-9-1",
                    endTime = "2018-1-1"
                },
                new {
                    id = 2,
                    name = "J2EE",
                    numClass = 1,
                    numStudent = 60,
                    teacherName ="邱明",
                    startTime = "2017-9-1",
                    endTime = "2018-1-1"
                }
            };
            result.Data = data;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // GET /course/{courseId}
        [System.Web.Http.Route("api/course/{courseId}")]
        [System.Web.Http.HttpGet]
        public ActionResult GetCourse(int courseId)
        {
            var result = new JsonResult();
            result.Data = new { id = 32, name = "OOAD", description = "面向对象分析与设计", teacherName = "邱明", teacherEmail = "mingqiu@xmu.edu.cn" };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // GET /course/{courseId}/seminar
        [System.Web.Http.Route("api/course/{courseId}/seminar")]
        [System.Web.Http.HttpGet]
        public ActionResult GetSeminarList(int courseId)
        {
            var result = new JsonResult();

            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context     
            HttpRequestBase request = context.Request;//定义传统request对象
            var embedGrade = request.Params["embedGrade"];
            var se = new object[] { new { id = 29, name = "界面原型设计", description = "界面原型设计", groupingMethod = "fixed", startTime = "2017-09-25", endTime = "2017-10-09", grade = 4 }, new { id = 32, name = "概要设计", description = "模型层与数据库设计", groupingMethod = "fixed", startTime = "2017-10-10", endTime = "2017-10-24", grade = 5 } };
            result.Data = new { name = "OOAD", se };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // GET /course/{courseId}/seminar/current
        [System.Web.Http.Route("api/course/{courseId}/seminar/current")]
        [System.Web.Http.HttpGet]
        public ActionResult GetCurrentSeminar(int courseId)
        {
            var result = new JsonResult();
            var classes = new object[] { new { id = 53, name = "周三12" }, new { id = 57, name = "周三34" } };
            result.Data = new { id = 29, name = "界面原型设计", courseName = "OOAD", groupingMethod = "fixed", startTime = "2017-09-25", endTime = "2017-10-09", classes };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}