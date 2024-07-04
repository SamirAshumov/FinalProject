
namespace ExamSystem.Core.Models
{
    public class Results
    {
        public string ExamName { get; set; }
        public List<Answer> answers { get; set; }
        public List<bool> isStudentPassed { get; set; }
        public List<string> StudentsStatus { get; set; }
        public int numberOfPassedStudent { get; set; }
        public int numberOfFailedStudent { get; set; }
        public int averageGrade { get; set; }
    }
}
