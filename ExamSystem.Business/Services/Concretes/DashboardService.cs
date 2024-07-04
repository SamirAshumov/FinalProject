using ExamSystem.Business.Services.Abstracts;
using ExamSystem.Core.Models;
using ExamSystem.Core.RepositoryAbstracts;

namespace ExamSystem.Business.Services.Concretes
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepo _dashboardRepo;

        public DashboardService(IDashboardRepo dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }

        public List<Dashboard> GetDashboards()
        {
            return _dashboardRepo.Dashboards();
        }

        public Results GetResults(int examId)
        {
            return _dashboardRepo.GetResult(examId);
        }

        public ExamAnswerResult GetExamDetails(int Id)
        {
            return _dashboardRepo.ExamDetails(Id);
        }
    }
}
