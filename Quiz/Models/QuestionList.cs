using System;
namespace Quiz.Models
{
	public class QuestionList
	{
        public int response_code { get; set; }
        public Question[] results { get; set; }
    }
}

