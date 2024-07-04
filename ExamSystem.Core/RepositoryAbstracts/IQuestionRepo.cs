using ExamSystem.Core.Models;

namespace ExamSystem.Core.RepositoryAbstracts
{
    public interface IQuestionRepo
    {
        ListOfQAndExamId listexq(int examId);
        void CreateQuestion(Question question);
        void DeleteQuestion(int Id);
        Question FindQuestion(int Id);
        void EditQuestion(Question question);
    }
}