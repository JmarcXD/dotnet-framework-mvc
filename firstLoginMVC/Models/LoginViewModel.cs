using System.ComponentModel.DataAnnotations;

namespace firstLoginMVC.Models
{
    public class LoginViewModel
    {

        [Required]               //Viene de la libreria system.datanotations
        [EmailAddress]           //Viene de la libreria system.datanotations
        [Display(Name ="Email")] //Viene de la libreria system.datanotations
        public string Email { get; set; }

        [Required]                    //Viene de la libreria system.datanotations
        [DataType(DataType.Password)] //Viene de la libreria system.datanotations
        [Display(Name = "Contraseña")] //Viene de la libreria system.datanotations
        public string Password { get; set; }
    }
}