using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("imagefile")]
    public class ImageFile
    {
        public Guid Id { get; set; }
        public string Folder { get; set; }
    }
}
