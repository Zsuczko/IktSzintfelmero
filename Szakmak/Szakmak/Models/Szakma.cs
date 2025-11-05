using System.ComponentModel.DataAnnotations;

namespace Szakmak.Models
{
    public class Szakma
    {
        [Key]
        public string Id { get; set; }
        public string  SzakmaNev { get; set; }
        public ICollection<Versenyzo>? Versenyzok { get; set; }
    }
}
