using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Template.Models
{  
    [Table("Tip")]
    public class Tip
    {   
        [Key]
        public int TipID {get;set;}

        [Required]
        public string Naziv {get;set;}
        
        [JsonIgnore]
        public List<Komponenta> TipKomponenta {get;set;}
    }
}