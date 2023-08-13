using System.ComponentModel.DataAnnotations;

namespace Models.Salao;

    public class Salao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Mesa_livres { get; set; }
        [Required]
        public int Mesas_reservadas { get; set; }
      
    }

