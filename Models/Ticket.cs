using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ToDoList.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a sprint number.")]
        [Range(1, int.MaxValue, ErrorMessage = "Sprint number must be greater than 0.")]
        public int SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter a point value.")]
        [Range(1, 100, ErrorMessage = "Point value must be between 1 and 100.")]
        public int PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; } = string.Empty;

        [ValidateNever]
        public Status? Status { get; set; }
    }
}
