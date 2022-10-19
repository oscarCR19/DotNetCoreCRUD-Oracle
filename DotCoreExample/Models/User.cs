using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace DotCoreExample.Models
{
    public class User
    {
         public int Id { get; set; }
        public string? nombre1 { get; set; }
        public string? nombre2 { get; set; }
        public string? apellido1 { get; set; }
        public string? apellido2 { get; set; }
        public string? correo { get; set; }
        public string? usuario { get; set; }
        public string? contra { get; set; }
        public string? foto { get; set; }
        public string? cedula { get; set; }
        public DateTime? fecha_nac { get; set; }

    }
}
