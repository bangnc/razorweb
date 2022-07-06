using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorweb.models
{
    [Table("Article")]
    public class Article {
        [Key]
        public int Id { get; set; }

        [StringLength(255, MinimumLength = 5 , ErrorMessage ="{0} phải dài từ {2} đến {1} ký tự")]
        [Required(ErrorMessage ="{0} phải nhập")]
        [Column(TypeName="nvarchar")]
        [DisplayName("Tiêu đề")]
        public string Title { get; set; }

        [DisplayName("Ngày tạo")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Created { get; set; }

        [DisplayName("Nội dung")]
        [Column(TypeName ="ntext")]
        public string Content { get; set; }

    }
    
}