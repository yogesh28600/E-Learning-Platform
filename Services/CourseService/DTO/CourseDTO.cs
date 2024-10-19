﻿using System.ComponentModel.DataAnnotations;

namespace CourseService.DTO
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid TrainerId { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
