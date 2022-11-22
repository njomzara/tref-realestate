using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Repositories.Model;

namespace DataModel
{
    public class Realestate : GenericEntity<Guid>
    {

        public Realestate()
        {

        }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string RealestateTypeId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string LocationId { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        [Required]
        public string Currency { get; set; }




        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; }

        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string CreateUserId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string UpdatedUserId { get; set; }

        /**
         * Relationship
         */

        [ForeignKey("RealestateTypeId")]
        public User RealestateType { get; set; }

        [ForeignKey("CreateUserId")]
        public User CreateUser { get; set; }

        [ForeignKey("UpdatedUserId")]
        public User UpdatedUser { get; set; }
    }
}
