﻿namespace TodoAPI.DTO
{
    public class TodoResposeDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public Guid UserId { get; set; }
    }
}
