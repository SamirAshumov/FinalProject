using ExamSystem.Core.Models;

namespace ExamSystem.Business.Services.Abstracts
{
    public interface IDashboardService
    {
        List<Dashboard> GetDashboards();
        Results GetResults(int examId);
        ExamAnswerResult GetExamDetails(int Id);
    }
}
