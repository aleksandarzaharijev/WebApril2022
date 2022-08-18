using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Template.Models
{  
    [Table("Komponenta")]
    public class Komponenta
    {
        [Key]
        public int KomponentaID {get;set;}

        [Required]
        public string Naziv {get;set;}

        public Tip Tip {get;set;}

        public Brend Brend {get;set;}
        
        [JsonIgnore]
        public List<Spoj> KomponentaProdavnica {get;set;}
    
        
    }
}