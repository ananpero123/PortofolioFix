using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Porto
    {
        [Key]
        public int id { get; set; }
        public string nama { get; set; } = string.Empty;
        public string deskripsi { get; set; } = string.Empty;
        public string pendidikan { get; set; } = string.Empty;
        public string keahlian { get; set; } = string.Empty;
        public string pengalaman { get; set; } = string.Empty;
        public string telp { get; set; } = string.Empty;
        public string link { get; set; } = string.Empty;
        public string foto { get; set; }
    }
}
