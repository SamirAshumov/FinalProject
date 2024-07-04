using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamSystem.Core.Models;

namespace Final_Exam_System.ViewModels
{
    public class ExamInformation
    {
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public AnswerQuestion Question { get; set; }
        public int NumOfQuestions { get; set; }
    }
}