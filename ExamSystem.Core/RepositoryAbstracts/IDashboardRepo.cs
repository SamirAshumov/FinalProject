using ExamSystem.Core.Models;

namespace ExamSystem.Core.RepositoryAbstracts
{
    public interface IDashboardRepo
    {
        List<Dashboard> Dashboards();
        Results GetResult(int examId);
        ExamAnswerResult ExamDetails(int Id);
    }
}