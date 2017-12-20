using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Test.Models;


namespace Xmu.Crms.HighGrade
{
    public class topicAPIController : ApiController
    {
        [System.Web.Http.Route("api/topic/{topicId}")]
        [System.Web.Http.HttpGet]
        public JsonResult GetTopic(int topicId)
        {
            JsonResult result = new JsonResult();
            /*
			Topic topic = new Topic();
			topic.id = 257;
			topic.serial = "A";
			topic.name = "领域模型与模块";
			topic.description = "Domain model与模块划分";
			topic.groupLimit = 5;
			topic.groupMemberLimit = 6;
			topic.groupLeft = 2;

			result.Data = topic;
			*/
            var data = new
            {
                id = 257,
                serial = "A",
                name = "领域模型与模块",
                description = "Domain model与模块划分",
                groupLimit = 5,
                groupMemberLimit = 6,
                groupLeft = 2
            };
            result.Data = data;

            return result;
        }

        [System.Web.Http.Route("api/topic/{topicId}")]
        [System.Web.Http.HttpPut]
        public ActionResult AlterTopic(int topicId)
        {
            JsonResult result = new JsonResult();
            /*
			Topic topic = new Topic();
			topic.id = 257;
			topic.serial = "A";
			topic.name = "领域模型与模块";
			topic.description = "Domain model与模块划分";
			topic.groupLimit = 6;
			topic.groupMemberLimit = 6;

			result.Data = topic;
			*/
            var data = new
            {
                id = 257,
                serial = "A",
                name = "领域模型与模块",
                description = "Domain model与模块划分",
                groupLimit = 5,
                groupMemberLimit = 6,
                groupLeft = 2
            };
            result.Data = data;

            return new HttpStatusCodeResult(204);
        }

        [System.Web.Http.Route("api/topic/{topicId}")]
        [System.Web.Http.HttpDelete]
        public ActionResult DeleteTopic(int topicId)
        {
            return new HttpStatusCodeResult(204);
        }

        [System.Web.Http.Route("api/topic/{topicId}/group")]
        [System.Web.Http.HttpGet]
        public JsonResult GetGroup(int topicId)
        {
            JsonResult result = new JsonResult();
            /*
			List<Group> groupList = new List<Group>();
			Group group1 = new Group();
			group1.id = 23.ToString();
			group1.name = "1A1";
			Group group2 = new Group();
			group1.id = 26.ToString();
			group1.name = "2A2";
			*/
            var data = new object[]
            {
                new {
                    id = "23",
                    name = "1A1"
                },
                new {
                    id = "26",
                    name = "2A2"
                }
            };
            result.Data = data;

            return result;
        }
    }
}
