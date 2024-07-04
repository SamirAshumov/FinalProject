using ExamSystem.Core.Models;

namespace ExamSystem.Core.RepositoryAbstracts
{
    public interface IExamRepo
    {
        List<ExamListAndNumQuestions> GetAllExams(string userId);
        void CreateExam(Exam exam, string userId);
        Exam FindExam(int id);
        void EditExam(int id, Exam exam);
        bool RemoveExam(int examId);
    }
}