using System.ComponentModel.DataAnnotations;

namespace taskmvc.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; } = string.Empty;

        public bool IsDone { get; set; }

    }
}
