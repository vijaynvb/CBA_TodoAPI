using NUnit.Framework;
using static RestAssured.Dsl;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TodoAPI.DTO;
using TodoAPI.Models;

namespace TodoAPI.Tests
{
    [TestFixture]
    public class TodosControllerTests
    {
        private const string BaseUrl = "https://localhost:5129/api/";

        [SetUp]
        public void Setup()
        {
            // Setup code if needed
        }

        [Test]
        public void GetTodo_ReturnsOk()
        {
            Given()
               .When()
               .Get($"{BaseUrl}Todos")
               .Then()
               .StatusCode(HttpStatusCode.OK);
        }

        [Test]
        public void GetTodoById_ReturnsOk()
        {
            var id = Guid.NewGuid(); // Replace with an existing ID
            Given()
               .When()
               .Get($"{BaseUrl}Todos/{id}")
               .Then()
               .StatusCode(HttpStatusCode.OK);
        }

        [Test]
        public void PostTodo_ReturnsCreated()
        {
            var todo = new TodoDTO
            {
                Title = "Test Todo",
                Description = "Test Description",
                DueDate = DateTime.Now.AddDays(1),
                UserId = Guid.NewGuid() // Replace with an existing User ID
            };

            Given()
                .Body(todo)
                .When()
                .Post($"{BaseUrl}Todos")
                .Then()
                .StatusCode(HttpStatusCode.Created);
        }

        [Test]
        public void PutTodo_ReturnsNoContent()
        {
            var id = Guid.NewGuid(); // Replace with an existing ID
            var todo = new TodoDTO
            {
                Title = "Updated Todo",
                Description = "Updated Description",
                DueDate = DateTime.Now.AddDays(2),
                UserId = Guid.NewGuid() // Replace with an existing User ID
            };

            Given()
                .Body(todo)
                .When()
                .Put($"{BaseUrl}Todos/{id}")
                .Then()
                .StatusCode(HttpStatusCode.NoContent);
        }

        [Test]
        public void DeleteTodo_ReturnsNoContent()
        {
            var id = Guid.NewGuid(); // Replace with an existing ID
            Given()
                .When()
                .Delete($"{BaseUrl}Todos/{id}")
                .Then()
                .StatusCode(HttpStatusCode.NoContent);
        }
    }
}
