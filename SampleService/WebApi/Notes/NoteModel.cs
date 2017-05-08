using System.ComponentModel.DataAnnotations;

namespace SampleService.WebApi.Notes
{
    public class NoteModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }
    }
}