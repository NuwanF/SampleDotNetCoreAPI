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
        public int ClubMeetId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int StrokeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Gender { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int Distance { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("ClubMeetId")]
        public virtual ClubMeet ClubMeet { get; set; }

        [ForeignKey("StrokeId")]
        public virtual Stroke Stroke { get; set; }

    }
}
