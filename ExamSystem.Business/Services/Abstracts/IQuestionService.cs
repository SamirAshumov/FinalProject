using ExamSystem.Core.Models;

namespace ExamSystem.Business.Services.Abstracts
{
    public interface IQuestionService
    {
        ListOfQAndExamId ListExQ(int examId);
        void CreateQuestion(Question question);
        void DeleteQuestion(int Id);
        Question FindQuestion(int Id);
        void EditQuestion(Question question);
    }
}
