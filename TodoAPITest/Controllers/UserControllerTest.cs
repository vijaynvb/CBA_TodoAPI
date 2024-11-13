using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestAssured.Dsl;
using System.Net;


namespace TodoAPITest.Controllers
{
    internal class UserControllerTest
    {
        [Test]
        public void GetAllUsersTest()
        {
            //AAA
            Given()
                .When()
                .Get("http://localhost:5129/api/users")
                .Then()
                .StatusCode(HttpStatusCode.OK);
        }
    }
}
