using System.ComponentModel.DataAnnotations;

namespace Models.Cadeiras;
 
    public class Cadeiras
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }


    }

