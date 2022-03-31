using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Entities
{
    
    public class Attendance
    {
       [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int  id { get; set; }
        public string firstname { get; set; }
        public string attendance { get; set; }
    }
    
}