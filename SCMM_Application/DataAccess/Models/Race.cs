using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Models
{
    public class Race
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RaceId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int RaceTypeId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int StrokeId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Venue { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public DateTime RaceDate { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; }

        public DateTime? ModifiedDate { get; set; }


        [ForeignKey("RaceTypeId")]
        public virtual RaceType RaceType { get; set; }

        [ForeignKey("StrokeId")]
        public virtual Stage Stroke { get; set; }

    }
}
