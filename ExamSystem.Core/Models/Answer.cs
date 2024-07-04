namespace ExamSystem.Core.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string StudentId { set; get; }
        public string StudentName { set; get; }
        public int? Score { set; get; }
        public bool IsSubmitted { get; set; } = false;
        public Exam Exams { get; set; }
        public int ExamId { get; set; }
    }
}
