using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Template.Models
{   
    [Table("Spoj")]
    public class Spoj
    { 
        [Key]
        public int SpojID {get;set;}

        public int Kolicina {get;set;}

        public int Cena {get;set;}

        public int Sifra {get;set;}
        
        
        public Komponenta Komponenta {get;set;}

        public Prodavnica Prodavnica {get;set;}

        
    }
}