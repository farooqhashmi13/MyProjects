﻿namespace PkHiveLibrary.Models
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int? SelectedOptionId { get; set; }
        public Option SelectedOption { get; set; }
        public bool IsRight { get; set; }
    }
}