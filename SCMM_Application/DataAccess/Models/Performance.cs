using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Models
{
    public class Performance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerformanceId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int StrokeId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int StageId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PersonalBestTime { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; }

        public DateTime? ModifiedDate { get; set; }


        [ForeignKey("StageId")]
        public virtual Stage Stage { get; set; }

        [ForeignKey("StrokeId")]
        public virtual Stroke Stroke { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
