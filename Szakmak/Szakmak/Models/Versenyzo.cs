using System.ComponentModel.DataAnnotations;

namespace Szakmak.Models
{
    public class Versenyzo
    {
        [Key]
        public int Id { get; set; }
        public string Nev { get; set; }
        public string SzakmaId { get; set; }
        public string OrszagId { get; set; }
        public int Pont { get; set; }

        public Orszag? Orszag { get; set; }
        public Szakma? Szakma { get; set; }
    }
}
