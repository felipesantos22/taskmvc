using System.ComponentModel.DataAnnotations;

namespace taskmvc.ViewModel.UserviewModel
{
    public class UserEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; } = string.Empty;
    }
}
