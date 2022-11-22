using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DataModel
{
    public class User : IdentityUser
    {

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmployeeId { get; set; }

    }
}
