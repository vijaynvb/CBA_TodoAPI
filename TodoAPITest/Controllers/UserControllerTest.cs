using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestAssured.Dsl;
using System.Net;
using TodoAPI.Models;
using TodoAPI.DTO;

namespace TodoAPITest.Controllers
{
    internal class UserControllerTest
    {
        string SERVER_BASE_URL;

        [SetUp]
        public void Setup()
        {
            SERVER_BASE_URL = "http://localhost:44342";
        }

        [Test]
        public void GetAllUsersTest()
        {
            //AAA
            Given()
                .When()
                .Get($"{SERVER_BASE_URL}/api/users")
                .Then()
                .StatusCode(HttpStatusCode.OK);
        }

        [TestCase("4716a36c-9ac6-4a29-cb77-08dd03b465c6")]
        public void GetUserByIdTest(Guid id)
        {
            //AAA
            string responseBodyAsString = (string) Given()
                .When()
                .Get($"{SERVER_BASE_URL}/api/users/{id}")
                .Then()
                .StatusCode(200)
                .Extract().Body("$.id");
            Assert.AreEqual(id.ToString(), responseBodyAsString);
        }
        
        [Test]
        public void PostUserTest()
        {
            //AAA

            UserDTO user = new UserDTO("ram", "r@g.com");

            string str = user.ToString();

            string responseBodyAsString = (string)Given()
                .When()
                .Post($"{SERVER_BASE_URL}/api/users")
                .Body(str)
                .Then()
                .StatusCode(201)
                .Extract().Body("$.id");

            Assert.NotNull(responseBodyAsString);
        }
    }
}
