using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Models
{
    public class UserRace
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int RaceId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Timing { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int Place { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; }

        public DateTime? ModifiedDate { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

    }
}
