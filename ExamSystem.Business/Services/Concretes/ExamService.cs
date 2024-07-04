using ExamSystem.Business.Services.Abstracts;
using ExamSystem.Core.Models;
using ExamSystem.Core.RepositoryAbstracts;

namespace ExamSystem.Business.Services.Concretes
{
    public class ExamService : IExamService
    {
        private readonly IExamRepo _examRepo;

        public ExamService(IExamRepo examRepo)
        {
            _examRepo = examRepo;
        }

        public List<ExamListAndNumQuestions> GetAllExams(string userId)
        {
            return _examRepo.GetAllExams(userId);
        }

        public void CreateExam(Exam exam, string userId)
        {
            _examRepo.CreateExam(exam, userId);
        }

        public Exam FindExam(int id)
        {
            return _examRepo.FindExam(id);
        }

        public void EditExam(int id, Exam exam)
        {
            _examRepo.EditExam(id, exam);
        }

        public bool RemoveExam(int examId)
        {
            return _examRepo.RemoveExam(examId);
        }
    }
}
