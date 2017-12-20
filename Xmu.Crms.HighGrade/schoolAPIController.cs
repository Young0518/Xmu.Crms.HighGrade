using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.IO;

namespace Xmu.Crms.HighGrade
{
    public class schoolAPIController : ApiController
    {

        // GET: api/school
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/school/province1")]
        public JsonResult GetProvince([FromBody]dynamic json)
        {
            var result = new JsonResult();
            var province = new object[] { "北京", "天津", "河北省", "福建", "......", "澳门特别行政区" };
            result.Data = province;
            return result;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/school/city1/province={province}")]
        public JsonResult GetCity(string province, [FromBody]dynamic json)
        {
            var result = new JsonResult();
            var data = new object[] { "福州", "漳州", "厦门", "......", "龙岩" };
            result.Data = data;
            return result;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/school/school1/city={city}")]
        public JsonResult GetSchool(string city, [FromBody]dynamic json)
        {
            var result = new JsonResult();
            var data = new object[] {
                new{id=32,name="厦门大学",province="福建",city="厦门" },
                new{id=37,name="厦门软件学院",province="福建",city="厦门" },
            };
            result.Data = data;
            return result;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/school/school")]
        public JsonResult PostSchool([FromBody]dynamic json)
        {
            JsonResult result = new JsonResult();
            var school = new { name = "厦门市人民公园", province = "福建", city = "厦门", id = 38 };
            var failed = false;
            string a = json.schoolname;
            if (a == "厦门大学" || a == "厦门软件学院")
                result.Data = failed;
            else
                result.Data = school.id;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // PUT: api/school/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}