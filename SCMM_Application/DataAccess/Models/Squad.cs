using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Models
{
    public class Squad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SquadId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int CoachId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Name { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; }

        public DateTime? ModifiedDate { get; set; }


        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        [ForeignKey("CoachId")]
        public virtual User Coach { get; set; }

    }
}
