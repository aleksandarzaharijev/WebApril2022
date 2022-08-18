using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Models;
namespace Template.Models
{   
    [Table("Prodavnica")]
    public class Prodavnica
    { 
        [Key]
        public int ProdavnicaID {get;set;}
        
        [Required]
        public string Naziv {get;set;}

        [JsonIgnore]
        public List<Spoj> ProdavnicaKomponenta {get;set;}
        
        
    }
}