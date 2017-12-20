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
    public class GroupController : ApiController
    {

        //GET /group/{groupId}
        [System.Web.Http.Route("api/group/{groupId}")]
        [System.Web.Http.HttpGet]
        public ActionResult GetGroup(int groupId)
        {
            var result = new JsonResult();
            //HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context     
            //HttpRequestBase request = context.Request;//定义传统request对象
            //var embedTopics = request.Params["embedTopics"];
            
                var members = new object[] { new { id = 5324, name = "李四" }, new { id = 5678, name = "王五" } };
                var topics = new object[] { new { id = 257, name = "领域模型与模块" } };
                result.Data = new { id = 28, leader = new { id = 8888, name = "张三" }, members, topics, report = "" };
            
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        //PUT /group/{groupId}/resign
        [System.Web.Http.Route("api/group/{groupId}/resign")]
        [System.Web.Http.HttpPut]
        public ActionResult PutResign(int groupId, dynamic id)
        {
            int stuId = id;
            return new HttpStatusCodeResult(204);
        }

        //PUT /group/{groupID}/assign
        [System.Web.Http.Route("api/group/{groupId}/assign")]
        [System.Web.Http.HttpPut]
        public ActionResult PutAssign(int groupId, dynamic id)
        {
            int stuId = id;
            return new HttpStatusCodeResult(204);
        }

        //POST /group/{groupId}/topic
        [System.Web.Http.Route("api/group/{groupId}/topic")]
        [System.Web.Http.HttpPost]
        public ActionResult PostTopic(int groupId, dynamic id)
        {
            int topicId = id;
            return new HttpStatusCodeResult(204);
        }

        //PUT /group/{groupId}/grade/presentation/{studentId}
        [System.Web.Http.Route("api/group/{groupId}/grade/presentation/{studentId}")]
        [System.Web.Http.HttpPut]
        public ActionResult PutGrade(int seminarId, int studentId, List<PresentationGrade> list)
        {
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
        }
    }
}
