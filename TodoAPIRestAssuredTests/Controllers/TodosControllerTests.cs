using NUnit.Framework;
using static RestAssured.Dsl;
using System;
using System.Collections.Generic;
using System.Net;
using TodoAPI.DTO;
using TodoAPI.Models;
using Namotion.Reflection;

namespace TodoAPI.Tests
{
    [TestFixture]
    [Order(1)]
    public class TodosControllerTests
    {
        private const string BaseUrl = "http://localhost:5000/api/Todos";
        private const string UsersUrl = "http://localhost:5000/api/Users";
        private Guid _createdTodoId;
        private Guid _createdUserId;

        [SetUp]
        public void SetUp()
        {
            var user = new
            {
                Name = "Test User",
                Email = "testuser@example.com"
            };

            _createdUserId = new Guid((string)Given()
                .Body(user)
                .When()
                .Post(UsersUrl)
                .Then()
                .StatusCode(HttpStatusCode.Created)
                .Extract().Body("$.id"));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Given()
                .When()
                .Delete($"{UsersUrl}/{_createdUserId}")
                .Then()
                .StatusCode(HttpStatusCode.NoContent);
        }

        [Test, Order(1)]
        public void PostTodo_ReturnsCreated()
        {
            var todo = new TodoDTO
            {
                Title = "Test Title",
                Description = "Test Description",
                DueDate = DateTime.Now.AddDays(1),
                UserId = _createdUserId
            };

            _createdTodoId = new Guid((string)Given()
                .Body(todo)
                .When()
                .Post(BaseUrl)
                .Then()
                .StatusCode(HttpStatusCode.Created)
                .Extract().Body("$.id"));
        }

        [Test, Order(2)]
        public void PutTodo_ReturnsNoContent()
        {
            var todo = new TodoDTO
            {
                Title = "Updated Title",
                Description = "Updated Description",
                DueDate = DateTime.Now.AddDays(2),
                UserId = _createdUserId
            };

            Given()
                .Body(todo)
                .When()
                .Put($"{BaseUrl}/{_createdTodoId}")
                .Then()
                .StatusCode(HttpStatusCode.NoContent);
        }

        [Test, Order(3)]
        public void GetTodo_ReturnsOk()
        {
            Given()
                .When()
                .Get(BaseUrl)
                .Then()
                .StatusCode(HttpStatusCode.OK);
        }

        [Test, Order(4)]
        public void GetTodoById_ReturnsOk()
        {
            Given()
                .When()
                .Get($"{BaseUrl}/{_createdTodoId}")
                .Then()
                .StatusCode(HttpStatusCode.OK);
        }

        [Test, Order(5)]
        public void DeleteTodo_ReturnsNoContent()
        {
            Given()
                .When()
                .Delete($"{BaseUrl}/{_createdTodoId}")
                .Then()
                .StatusCode(HttpStatusCode.NoContent);
        }
    }
}
