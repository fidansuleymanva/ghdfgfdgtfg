using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBusiness.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100,ErrorMessage="Image olcusu uygun deyil!")]
        public string? Image { get; set; }
        public string FURL { get; set; }
        public string TURL { get; set; }
        public string IURL { get; set; }
        [StringLength(maximumLength:50, ErrorMessage= "FullName olcusu uygun deyil!")]
        public string FullName { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Perssion olcusu uygun deyil!")]
        public string Perssion { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
