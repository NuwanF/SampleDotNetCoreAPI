using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Models
{
    public class RaceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RaceTypeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Gender { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int Distance { get; set; }

    }
}
