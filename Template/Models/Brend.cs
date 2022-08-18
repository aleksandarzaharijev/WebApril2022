using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Template.Models
{   
    [Table("Brend")]
    public class Brend
    { 
        [Key]

        public int BrendID {get;set;}

        [Required]
        public string Naziv {get;set;}
        
        [JsonIgnore]
        public List<Komponenta> BrendKomponenta {get;set;}
    }
}