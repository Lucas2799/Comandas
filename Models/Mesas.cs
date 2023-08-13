using System.ComponentModel.DataAnnotations;
using C = Models.Cadeiras;

namespace Models.Mesas;

    public class Mesas
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        [Required]
        public C.Cadeiras? Cadeiras { get; set; }
        
    }

