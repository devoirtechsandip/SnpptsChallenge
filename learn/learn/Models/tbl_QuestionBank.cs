using System;
using System.Collections.Generic;
using System.Text;

namespace learn.Models
{
	public class tbl_QuestionBank
	{
		public string pk { get; set; }
		public string SubjectId { get; set; }
		public string Question { get; set; }
		public string OptionA { get; set; }
		public string OptionB { get; set; }
		public string OptionC { get; set; }
		public string OptionD { get; set; }
		public string CorrectAns { get; set; }
		public string ExamDate { get; set; }
		public string QuestionExplaination { get; set; }
	}
}
