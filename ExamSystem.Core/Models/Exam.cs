using System.ComponentModel.DataAnnotations;

namespace ExamSystem.Core.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int Duration { set; get; }
        public DateTime? AddedAt { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public ApplicationUser ApplicationUser { set; get; }
        public string ApplicationUserId { get; set; }
    }
}