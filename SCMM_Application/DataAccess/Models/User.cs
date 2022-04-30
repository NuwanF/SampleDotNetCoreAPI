using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int UserRoleId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public DateTime DOB { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Mobile { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Username { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }
    }
}
