
namespace ExamSystem.Core.Models
{
    public class ListOfQAndExamId
    {
        public string ExamName { get; set; }
        public DateTime? StartTime { get; set; }
        public List<Question> questions { get; set; }
        public int Id { get; set; }
    }
}
