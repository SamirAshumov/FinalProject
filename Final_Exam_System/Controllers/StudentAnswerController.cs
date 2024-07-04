using ExamSystem.Business.Services.Abstracts;
using ExamSystem.Core.Models;
using Final_Exam_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Exam_System.Controllers
{
    public class StudentAnswerController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentAnswerController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var exam = _studentService.GetExam(id);

            if (exam == null)
                return RedirectToAction("Index", "Home");

            var startTime = exam.StartTime;
            var endTime = exam.EndTime;

            var model = new StudentInfo
            {
                ExamId = id,
                StudentId = "",
                Name = "",
                StartTime = (DateTime)startTime,
                EndTime = (DateTime)endTime
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddAnswer(StudentInfo student)
        {
            int answerId = 0;

            var checkStudent = _studentService.GetAnswer(student.StudentId, student.ExamId);
            if (checkStudent != null)
            {
                answerId = checkStudent.AnswerId;
                if (checkStudent.IsSubmitted)
                {
                    return RedirectToAction("Submit", new { AnswerId = checkStudent.AnswerId });
                }
            }
            else
            {
                var studentAns = _studentService.AddStudentAnswer(student);
                var questions = _studentService.GetQuestions(student.ExamId);
                _studentService.AddAnswerQuestions(questions, studentAns.AnswerId);
                answerId = studentAns.AnswerId;
            }

            var indexAndAnswerId = new IndexAndAnswerId { Index = 0, AnswerId = answerId };
            return RedirectToAction("StudentExam", indexAndAnswerId);
        }

        [HttpGet]
        public IActionResult StudentExam(IndexAndAnswerId indexAndAnswerId)
        {
            var question = _studentService.GetAnswerQuestion(indexAndAnswerId.Index, indexAndAnswerId.AnswerId);

            if (question == null)
                return RedirectToAction("Submit", new { AnswerId = indexAndAnswerId.AnswerId });

            var numOfQuestions = _studentService.GetAnswerQuestions(indexAndAnswerId.AnswerId).Count();
            var answer = _studentService.GetAnswer(indexAndAnswerId.AnswerId);
            var exam = _studentService.GetExam(answer.ExamId);

            var examInformation = new ExamInformation
            {
                ExamName = exam.Title,
                ExamDate = (DateTime)exam.EndTime,
                Question = question,
                NumOfQuestions = numOfQuestions
            };

            return View(examInformation);
        }

        [HttpPost]
        public IActionResult StudentExam(IFormCollection form)
        {
            int index = 0, answerId = 0;

            if (int.TryParse(form["question.Index"], out index)) { }
            else return NotFound();

            if (int.TryParse(form["question.AnswerId"], out answerId)) { }
            else return NotFound();

            string action = form["action"];
            if (action == "prev")
                index--;
            else if (action == "next")
                index++;
            else if (action == "submit")
                return RedirectToAction("Submit", new { AnswerId = answerId });

            return RedirectToAction("StudentExam", new IndexAndAnswerId { Index = index, AnswerId = answerId });
        }

        [HttpPost]
        public JsonResult CalculateResult(int answerId, int selectedChoice, int questionIndex)
        {
            var question = _studentService.GetAnswerQuestion(questionIndex, answerId);
            if (question != null)
            {
                if (selectedChoice != 0)
                {
                    _studentService.UpdateAnswerQuestion(question, (byte)selectedChoice);
                    var studentAnswerIndex = _studentService.GetStudentAnswerIndex(answerId, questionIndex);
                    _studentService.InsertOrUpdateStudentAnswerIndex(studentAnswerIndex, answerId, questionIndex, question.SelectedAnswer, question.TrueAnswer);
                    _studentService.UpdateScore(answerId);
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Submit(int answerId)
        {
            var check = _studentService.CheckExistenceAnswer(answerId);
            if (!check)
                return NotFound();

            int score = _studentService.GetScoreAfterSubmission(answerId);
            return View(score);
        }
    }
}