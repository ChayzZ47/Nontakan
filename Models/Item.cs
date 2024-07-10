using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nontakan.Models
{
    public class Item
    {
        public int Id { get; set; }

        // ตรวจสอบว่า property 'Title' มีอยู่ในโมเดลหรือไม่
        // ถ้าไม่มี ให้เพิ่ม property นี้ลงไป
        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        [NotMapped]
        public string ImageBase64 { get; set; }
    }


}