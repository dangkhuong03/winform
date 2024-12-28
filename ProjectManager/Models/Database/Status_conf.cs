using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("Status_conf")]
    public class Status_conf
    {
      
        [Key]
        [Column("Id")]
        public string Id { get; set; }  // Project ID

        [Column("Status")]
        [Required]  // Not null
        public string Status { get; set; }  // Project Name

    }
}
