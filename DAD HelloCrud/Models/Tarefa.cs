using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DAD_HelloCrud.Models
{
    public class Tarefa
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nomes não devem conter números e/ou caracteres.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A dificuldade deve ser informada.")]
        [StringLength(3, ErrorMessage = "Dificuldade valida de três digitos numéricos.")]
        [RegularExpression(@"^([1-9]|[1-8][0-9]|9[0-9]|1[01][0-9]|120)$", ErrorMessage = "Dificuldade válida entre 1 e 120 pontos.")]
        [Display(Name = "Dificuldade")]
        public string dificuldade { get; set; }

        public bool feita { get; set; }
    }
}