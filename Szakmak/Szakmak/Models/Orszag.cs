using System.ComponentModel.DataAnnotations;

namespace Szakmak.Models
{
    public class Orszag
    {
        [Key]
        public string Id { get; set; }
        public string OrszagNev { get; set; }

        public ICollection<Versenyzo>? Versenyzok { get; set; }
    }
}
