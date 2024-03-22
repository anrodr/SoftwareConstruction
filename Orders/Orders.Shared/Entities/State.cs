using Orders.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.Entities
{
    internal class State: IEntityWithName
    {
public int Id { get; set; }
        [Display(Name = "Departamento / Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracteres.")]
        [Required(ErrorMessage = "El campo {0} no puede ser nullo")]

        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        public Country? Country { get; set; }
    }
}
