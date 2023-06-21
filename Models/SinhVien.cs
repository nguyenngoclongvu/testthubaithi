using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NguyenNGocLongVu_33.Models
{
    public class SinhVien
    {
        [Key]
        public string MaSinhvien { get; set; }
        public string HoTen { get; set; }
        public string MaLop { get; set; }
    }
}