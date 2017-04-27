using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flicker.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Body { get; set; }
        public int ImageId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Image Image { get; set; }
    }
}
