
using System.ComponentModel.DataAnnotations;

namespace Final_Exam_System.ViewModels
{
    public class StringId
    {
        [Required(ErrorMessage = "Please enter an exam ID.")]
        [Display(Name = "Id")]
        public string Id { get; set; }
        public List<int>? ExamIds { get; set; }
    }
}