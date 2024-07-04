using ExamSystem.Core.Models;

namespace ExamSystem.Business.Services.Abstracts
{
    public interface IStudentService
    {
        Exam GetExam(int id);
        Answer GetAnswer(int AnswerId);
        Answer GetAnswer(string StudentId, int ExamId);
        Answer AddStudentAnswer(StudentInfo studentInfo);
        Answer GetStudentAnswer(string StudentId);
        List<Question> GetQuestions(int ExamId);
        void AddAnswerQuestions(List<Question> questions, int answerId);
        AnswerQuestion GetAnswerQuestion(int index, int AnswerId);
        List<AnswerQuestion> GetAnswerQuestions(int AnswerId);
        StudentAnswerIndex GetStudentAnswerIndex(int AnswerId, int Index);
        void InsertOrUpdateStudentAnswerIndex(StudentAnswerIndex studentAsnwerIndex, int AnswerId, int Index, byte selectedAnswer, byte trueAnswer);
        void UpdateScore(int AnswerId);
        void UpdateAnswerQuestion(AnswerQuestion question, byte selectedOption);
        bool CheckExistenceAnswer(int AnswerId);
        int GetScoreAfterSubmission(int AnswerId);
    }
}
