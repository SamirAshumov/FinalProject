using Microsoft.AspNetCore.Mvc;
using ExamSystem.Business.Services.Abstracts;
using ExamSystem.Core.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Final_Exam_System
{
    [Authorize]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;
        private readonly IDashboardService _dashboardService;

        public ExamController(IExamService examService, IQuestionService questionService, IDashboardService dashboardService)
        {
            _examService = examService;
            _questionService = questionService;
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var examList = _examService.GetAllExams(userId);
            return View(examList);
        }

        [HttpGet]
        public IActionResult CreateExam()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExam(Exam item)
        {
            _examService.CreateExam(item, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction("Index");
        }

        public IActionResult EditExam(int id)
        {
            var item = _examService.FindExam(id);
            if (item == null)
                return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExam(Exam item)
        {
            _examService.EditExam(item.ExamId, item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var remove = _examService.RemoveExam(id);
            if (!remove)
                return NotFound();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewQuestions(int id)
        {
            var exam = _examService.FindExam(id);
            if (exam == null)
                return NotFound();

            var examWithQuestions = _questionService.ListExQ(id);
            return View(examWithQuestions);
        }

        [HttpGet]
        public IActionResult CreateQuestion(int id)
        {
            var question = new Question { ExamId = id };
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuestion(Question item)
        {
            _questionService.CreateQuestion(item);
            return RedirectToAction("ViewQuestions", new { id = item.ExamId });
        }

        [HttpGet]
        public IActionResult DeleteQuestion(int id)
        {
            var question = _questionService.FindQuestion(id);
            if (question == null)
                return NotFound();

            _questionService.DeleteQuestion(id);
            return RedirectToAction("ViewQuestions", new { id = question.ExamId });
        }

        [HttpGet]
        public IActionResult EditQuestion(int id)
        {
            var question = _questionService.FindQuestion(id);
            if (question == null)
                return NotFound();
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuestion(Question item)
        {
            _questionService.EditQuestion(item);
            return RedirectToAction("ViewQuestions", new { id = item.ExamId });
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var dashboards = _dashboardService.GetDashboards();
            return View(dashboards);
        }

        [HttpGet]
        public IActionResult ViewResults(int id)
        {
            var model = _dashboardService.GetResults(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpGet]
        public IActionResult ExamResultDetails(int id)
        {
            var model = _dashboardService.GetExamDetails(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
    }
}