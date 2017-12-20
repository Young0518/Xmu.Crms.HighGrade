using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Mvc;
using Test.Models;

namespace Xmu.Crms.HighGrade
{
    public class classAPIController : ApiController
    {

        [System.Web.Http.Route("api/class/{classId}/attendance")]
        [System.Web.Http.HttpGet]
        public ActionResult GetAttendence()
        {
            JsonResult result = new JsonResult();
            var data = new
            {
                numPresent = 4,
                present = new object[]
                {
                    new {
                        id=2357,
                        nameof="张三"
                    },
                    new {
                        id = 8232,
                        nameof = "李四"
                    }
                }
            };
            result.Data = data;
            return result;
        }

        [System.Web.Http.Route("api/class")]
        [System.Web.Http.HttpGet]
        public JsonResult GetClassList(int userId)
        {
            JsonResult result = new JsonResult();
            /*
			Class class1 = new Class();
			Class class2 = new Class();
			class1.id = 23;
			class1.name = "二班";
			class1.numStudent = 60;
			class1.time = "周三1-2、周五1-2";
			class1.site = "公寓405";
			//class1.getCourse().name = "OOAD";
			//class1.getCourse().teacher.name = "邱明";
			class2.id = 42;
			class2.name = "一班";
			class2.numStudent = 60;
			class2.time = "周三34节、周五12节";
			class2.site = "海韵202";
			//class1.getCourse().name = ".Net平台开发";
			//class1.getCourse().teacher.name = "杨律青";
			var data = new { class1, class2 };
			result.Data = data;
			*/
            var data = new object[]
            {
                new {
                    id=23,
                    name="二班",
                    numStudent=60,
                    time="周三1-2、周五1-2",
                    site="公寓405",
                    courseName="OOAD",
                    courseTeacher="邱明"
                },
                new {
                    id=42,
                    name="一班",
                    numStudent=60,
                    time="周三34节、周五12节",
                    site="海韵202",
                    courseName=".Net平台开发",
                    courseTeacher="杨律青"
                },
            };
            result.Data = data;
            return result;
        }


        [System.Web.Http.Route("api/class/{classId}")]
        [System.Web.Http.HttpGet]
        public JsonResult GetClassAbstract(int classId)
        {
            JsonResult result = new JsonResult();
            var proportion = new
            {
                report = 50,
                presentation = 50,
                c = 20,
                b = 60,
                a = 20
            };
            var data = new
            {
                id = 23,
                name = "一班",
                numStudent = 120,
                time = "周三12节",
                site = "海韵201",
                calling = -1,
                roster = "/roster/周三12班.xlsx",
                proportions = proportion
            };
            result.Data = data;
            return result;
        }


        [System.Web.Http.Route("api/class/{classId}")]
        [System.Web.Http.HttpPut]
        public JsonResult FixedRollStartCall()
        {
            JsonResult result = new JsonResult();
            var data = new object[]
            {
                new {
                    id=23,
                    name="二班",
                    numStudent=60,
                    time="周三1-2、周五1-2",
                    site="公寓405",
                    courseName="OOAD",
                    courseTeacher="邱明"
                },
                new {
                    id=42,
                    name="一班",
                    numStudent=60,
                    time="周三34节、周五12节",
                    site="海韵202",
                    courseName=".Net平台开发",
                    courseTeacher="杨律青"
                },
            };
            result.Data = data;
            return result;
        }


        /*//手机端没有
		[System.Web.Http.Route("api/class/{classId}")]
		[System.Web.Http.HttpDelete]
		public JsonResult DeleteClass()
		{
			JsonResult result = new JsonResult();
			return result;
		}
		*/

        [System.Web.Http.Route("api/class/{classId}/student")]
        [System.Web.Http.HttpGet]
        public JsonResult GetStudentList(int classId, String numBeginWith, String nameBeginWith)
        {
            JsonResult result = new JsonResult();
            var data = new object[] {
                new {
                    id = 233,
                    name = "张三",
                    number = 24320152202333,
                },
                new {
                    id = 245,
                    name = "张八",
                    number = 24320152202334,
                }
            };
            result.Data = data;
            return result;
        }

        /*//手机端没有
		[System.Web.Http.Route("api/class/{classId}/student")]
		[System.Web.Http.HttpPost]
		public JsonResult ChooseClassById()
		{
			JsonResult result = new JsonResult();
			return result;
		}
		*/

        /*//手机端没有
		[System.Web.Http.Route("api/class/{classId}/student/{studentId}")]
		[System.Web.Http.HttpDelete]
		public JsonResult DeleteClassChoice()
		{
			JsonResult result = new JsonResult();
			return result;
		}
		*/

        [System.Web.Http.Route("api/class/{classId}/classgroup")]
        [System.Web.Http.HttpGet]
        public JsonResult GetMyClassGroup(int classId)
        {
            JsonResult result = new JsonResult();
            var tleader = new
            {
                id = 2757,
                name = "张三",
                number = 24320152202333,
            };
            var tmember = new object[] {
                new {
                    id = 2756,
                    name = "李四",
                    number = 24320152202443,
                },
                new {
                    id = 2777,
                    name = "王五",
                    number = 24320152202433,
                }
            };
            var data = new
            {
                leader = tleader,
                member = tmember
            };
            result.Data = data;
            return result;
        }

        [System.Web.Http.Route("api/class/{classId}/classgroup/resign")]
        [System.Web.Http.HttpPut]
        public ActionResult GroupResign(int id)
        {
            Student stu = new Student();
            Group gro = new Group();
            gro.leader = null;
            return new HttpStatusCodeResult(204);
        }

        [System.Web.Http.Route("api/class/{classId}/classgroup/assign")]
        [System.Web.Http.HttpPut]
        public ActionResult GroupAssign()
        {
            Student stu = new Student();
            Group gro = new Group();
            gro.leader = null;
            return new HttpStatusCodeResult(204);
        }

        [System.Web.Http.Route("api/class/{classId}/classgroup/add")]
        [System.Web.Http.HttpPut]
        public ActionResult AddGroupMember()
        {
            Student stu = new Student();
            Group group = new Group();
            group.members.Add(stu);
            return new HttpStatusCodeResult(204);
        }

        [System.Web.Http.Route("api/class/{classId}/classgroup/remove")]
        [System.Web.Http.HttpPut]
        public ActionResult RemoveGroupMember()
        {
            Student stu = new Student();
            Group group = new Group();
            group.members.Remove(stu);
            return new HttpStatusCodeResult(204);
        }

    }
}
