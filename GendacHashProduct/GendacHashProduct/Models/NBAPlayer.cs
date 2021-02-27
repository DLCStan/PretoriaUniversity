using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GendacHashProduct.Models
{
    public class NBAPlayer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string PlayerName { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string TeamName { get; set; }

        [Range(1, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PointsPerGame { get; set; }
    }
}
