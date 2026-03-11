using System.ComponentModel.DataAnnotations;

namespace FoldrengesekSOE2026.Models
{
    public class Telepules
    {
        public int ID { get; set; } // a VS kitalálja, hogy ez egy elsődleges kulcs lesz!
        [Required]
        [Display(Name = "Település név")]
        public string Nev { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Vármegye")]
        public string Varmegye { get; set; } = string.Empty;

        // Navigáció: településhez tartozó naplóbejegyzések lekéréséhez:
        public virtual ICollection<Naplo>? Naplok { get; set; } = new List<Naplo>();

    }
}
