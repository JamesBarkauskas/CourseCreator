using System.ComponentModel.DataAnnotations;

namespace CourseCreatorWeb.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CreditHours { get; set; }

    }
}
