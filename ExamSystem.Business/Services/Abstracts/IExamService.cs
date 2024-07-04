using ExamSystem.Core.Models;

namespace ExamSystem.Business.Services.Abstracts
{
    public interface IExamService
    {
        List<ExamListAndNumQuestions> GetAllExams(string userId);
        void CreateExam(Exam exam, string userId);
        Exam FindExam(int id);
        void EditExam(int id, Exam exam);
        bool RemoveExam(int examId);
    }
}
