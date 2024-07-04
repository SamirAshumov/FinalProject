using ExamSystem.Business.Services.Abstracts;
using ExamSystem.Core.Models;
using ExamSystem.Core.RepositoryAbstracts;

namespace ExamSystem.Business.Services.Concretes
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public Exam GetExam(int id)
        {
            return _studentRepo.GetExam(id);
        }

        public Answer GetAnswer(int AnswerId)
        {
            return _studentRepo.GetAnswer(AnswerId);
        }

        public Answer GetAnswer(string StudentId, int ExamId)
        {
            return _studentRepo.GetAnswer(StudentId, ExamId);
        }

        public Answer AddStudentAnswer(StudentInfo studentInfo)
        {
            return _studentRepo.AddStudentAnswer(studentInfo);
        }

        public Answer GetStudentAnswer(string StudentId)
        {
            return _studentRepo.GetStudentAnswer(StudentId);
        }

        public List<Question> GetQuestions(int ExamId)
        {
            return _studentRepo.GetQuestions(ExamId);
        }

        public void AddAnswerQuestions(List<Question> questions, int answerId)
        {
            _studentRepo.AddAnswerQuestions(questions, answerId);
        }

        public AnswerQuestion GetAnswerQuestion(int index, int AnswerId)
        {
            return _studentRepo.GetAnswerQuestion(index, AnswerId);
        }

        public List<AnswerQuestion> GetAnswerQuestions(int AnswerId)
        {
            return _studentRepo.GetAnswerQuestions(AnswerId);
        }

        public StudentAnswerIndex GetStudentAnswerIndex(int AnswerId, int Index)
        {
            return _studentRepo.GetStudentAnswerIndex(AnswerId, Index);
        }

        public void InsertOrUpdateStudentAnswerIndex(StudentAnswerIndex studentAsnwerIndex, int AnswerId, int Index, byte selectedAnswer, byte trueAnswer)
        {
            _studentRepo.InsertOrUpdateStudentAnswerIndex(studentAsnwerIndex, AnswerId, Index, selectedAnswer, trueAnswer);
        }

        public void UpdateScore(int AnswerId)
        {
            _studentRepo.UpdateScore(AnswerId);
        }

        public void UpdateAnswerQuestion(AnswerQuestion question, byte selectedOption)
        {
            _studentRepo.UpdateAnswerQuestion(question, selectedOption);
        }

        public bool CheckExistenceAnswer(int AnswerId)
        {
            return _studentRepo.CheckExistenceAnswer(AnswerId);
        }

        public int GetScoreAfterSubmission(int AnswerId)
        {
            return _studentRepo.GetScoreAfterSubmission(AnswerId);
        }
    }
}
