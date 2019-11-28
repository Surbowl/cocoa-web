using System.ComponentModel.DataAnnotations;

namespace CoreMe.Models
{
    public class MessageViewModel
    {
        [Display(Name = "称呼*")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "请告诉我您的称呼，以便答复")]
        [StringLength(100, ErrorMessage = "您输入的称呼过长，还望缩减一些")]
        public string name { get; set; }

        [Display(Name = "电子邮箱*")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "您输入的电子邮箱似乎有误")]
        [Required(ErrorMessage = "请告诉我您的邮箱，以便答复")]
        [StringLength(120, ErrorMessage = "很抱歉，仅支持最长120位的电子邮箱")]
        public string email { get; set; }

        [Display(Name = "联系电话")]
        [DataType(DataType.PhoneNumber)]
        //[Phone(ErrorMessage = "您输入的联系电话似乎有误")]
        [StringLength(15, ErrorMessage = "您输入的联系电话似乎有误", MinimumLength = 11)]
        public string phone { get; set; }

        [Display(Name = "消息内容*")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "请输入消息内容")]
        [StringLength(2000, ErrorMessage = "很抱歉，此处仅支持最长2000字的消息")]
        public string content { get; set; }
    }
}
