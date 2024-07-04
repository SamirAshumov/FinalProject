using ExamSystem.Business.Services.Abstracts;
using ExamSystem.Core.Models;
using ExamSystem.Core.RepositoryAbstracts;

namespace ExamSystem.Business.Services.Concretes
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionService(IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public ListOfQAndExamId ListExQ(int examId)
        {
            return _questionRepo.listexq(examId);
        }

        public void CreateQuestion(Question question)
        {
            _questionRepo.CreateQuestion(question);
        }

        public void DeleteQuestion(int Id)
        {
            _questionRepo.DeleteQuestion(Id);
        }

        public Question FindQuestion(int Id)
        {
            return _questionRepo.FindQuestion(Id);
        }

        public void EditQuestion(Question question)
        {
            _questionRepo.EditQuestion(question);
        }
    }
}
