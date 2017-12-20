
using Test.Models;
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
    public class seminarAPIController : ApiController
    {
        /*[System.Web.Http.HttpGet]
        public ActionResult GetGroup(int seminarId)
        {
            var result = new JsonResult();
            var gradeable = Request["gradeable"];
            if (gradeable == "true")
            {
                result.Data = new object[] { new Group{ id = 27, name = "1-A-1" }, new Group{ id = 28, name = "1-A-2" }, new Group{ id = 29, name = "1-B-1" },
                    new Group{ id = 30, name = "1-B-2" }, new Group{ id = 31, name = "1-C-1" }, new Group{ id = 32, name = "1-C-2" } };
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        */
        // GET /seminar/{seminarId}
        [System.Web.Http.Route("api/seminar/{seminarId}")]
        [System.Web.Http.HttpGet]
        public ActionResult GetSeminar(int seminarId)
        {
            var result = new JsonResult();
            result.Data =  new Seminar { id = 32, name = "概要设计", courseName = "OOAD", description = "模型层与数据库设计", groupingMethod = "fixed", startTime = "2017-10-10", endTime = "2017-10-24" };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        /*[System.Web.Http.Route("seminar/{seminarId}")]
        [System.Web.Http.HttpPut]
        public ActionResult PutGrade(int seminarId, int studentId)
        {
            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var list = jss.Deserialize<List<PresentationGrade>>(stream);
            List<PresentationGrade> pgl = new List<PresentationGrade>();
            if (list.Any())
            {
                foreach (var item in list)
                {
                    PresentationGrade pg = new PresentationGrade();
                    pg.topicId = item.topicId;
                    pg.grade = item.grade;
                    pgl.Add(pg);
                }
            }
            return new HttpStatusCodeResult(204);
        }*/

        //PUT /seminar/{seminarId}
        //[HttpPut]
        //public ActionResult PutSeminar(int seminarId)
        //{
        //    var sr = new StreamReader(Request.InputStream);
        //    var stream = sr.ReadToEnd();
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    var list = jss.Deserialize<List<Seminar>>(stream);
        //    List<Seminar> sel = new List<Seminar>();
        //    if (list.Any())
        //    {
        //        foreach (var item in list)
        //        {
        //            Seminar se = new Seminar();
        //            item.id = se.id;
        //            item.name = se.name;
        //            item.description = se.description;
        //            item.groupingMethod = se.groupingMethod;                   
        //            item.startTime = se.startTime;
        //            item.endTime = se.endTime;
        //            item.topics = se.topics;
        //        }
        //    }
        //    return new HttpStatusCodeResult(204);
        //}

        //[HttpDelete]
        //public ActionResult DeleteSeminar(int seminarId)
        //{
        //    return new HttpStatusCodeResult(204);
        //}

        //GET /seminar/{seminarId}/detail
        [System.Web.Http.Route("api/seminar/{seminarId}/detail")]
        [System.Web.Http.HttpGet]
        public ActionResult GetSeminarDetail(int seminarId)
        {
            var result = new JsonResult();
            result.Data = new { id = 32, name = "概要设计", startTime = "2017-10-10", endTime = "2017-10-24", site = "海韵201", teacherName = "邱明", teacherEmail = "mingqiu@xmu.edu.cn" };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        //GET /seminar/{seminarId}/topic
        [System.Web.Http.Route("api/seminar/{seminarId}/topic")]
        [System.Web.Http.HttpGet]
        public ActionResult GetTopic(int seminarId)
        {
            var result = new JsonResult();
            result.Data = new object[] { new { id = 257, serial = "A", name = "领域模型与模块", description = "Domain model与模块划分", groupLimit = 5, groupMemberLimit = 6, groupLeft = 2 } , new { id = 257, serial = "B", name = "用例分析", description = "Use Cases", groupLimit = 5, groupMemberLimit = 6, groupLeft = 1 } };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        //GET /seminar/{seminarId}/group/my
        [System.Web.Http.Route("api/seminar/{seminarId}/group/my")]
        [System.Web.Http.HttpGet]
        public ActionResult GetMy(int seminarId)
        {
            var result = new JsonResult();
            var members = new object[] { new { id = 5324, name = "李四" }, new { id = 5678, name = "王五" } };
            var topics = new object[] { new { id = 257, name = "领域模型与模块" } };
            result.Data = new { id = 28, name = "讨论课4", leader = new { id = 8888, name = "张三" }, members, topics };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        //GET /seminar/{seminarId}/class/{classId}/attendance
        [System.Web.Http.Route("api/seminar/{seminarId}/class/{classId}/attendance")]
        [System.Web.Http.HttpGet]
        public ActionResult GetAttendance(int seminarId, int classId)
        {
            var result = new JsonResult();
            result.Data = new { numPresent = 40, numStudent = 60, status = "calling", group = "grouping" };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }


        //GET /seminar/{seminarId}/group
        [System.Web.Http.Route("api/seminar/{seminarId}/group")]
        [System.Web.Http.HttpGet]
        public ActionResult GetGroup(int seminarId)
        {
            var result = new JsonResult();

            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context     
            HttpRequestBase request = context.Request;//定义传统request对象
            var gradeable = request.Params["gradeable"];
            var classId = request.Params["classId"];
            var include = request.Params["include"];

            
                result.Data = new object[] { new { id = 27, name = "1-A-1" ,topicName="界面设计"}, new { id = 28, name = "1-A-2", topicName = "模型层设计" }, new { id = 29, name = "1-B-1", topicName = "界面设计" }, new { id = 30, name = "1-B-2", topicName = "界面设计" }, new { id = 31, name = "1-C-1", topicName = "界面设计" }, new { id = 32, name = "1-C-2", topicName = "界面设计" } };
            
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}
