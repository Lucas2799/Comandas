using System.ComponentModel.DataAnnotations;
using C = Models.Cadeiras;
using M = Models.Mesas;

namespace Models.Reservas;

    public class Reservas

    {
        [Key]
        public int Id { get; set; }
        public M.Mesas Numero_Mesa { get; set; }
        //public C.Cadeiras Cadeiras { get; set; }
        
    }

