using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Entities
{
    
    public class Employes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  rollno { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

         
        public string gender { get; set; }
        public string phoneno { get; set; }
        public string mail { get; set; }
        public string password { get; set; }


    }
    
}