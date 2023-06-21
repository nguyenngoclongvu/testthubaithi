using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NguyenNGocLongVu_33.Models
{
    public class LopHoc
    {
        [Key]
        public string MaLop { get; set; }
        public string TenLop { get; set; }
    }
}