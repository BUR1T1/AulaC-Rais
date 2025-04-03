using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novaula.models
{
    
    public class Pivete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get; set;}
        public string? Nome{get; set;}
        public string? problema{get; set;}
        public int? idade{get; set;}


    }
}