using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flicker.Models
{
    [Table("Images")]
    public class Image
    {
        public Image()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int ImageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
