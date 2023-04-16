using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("studyTips")]
    public class StudyTips : BaseEntity
    {
        public StudyTips()
        {

        }

        public string TipName { get; set; }

        [ForeignKey("study")]
        public int StudyId { get; set; }
   
        public Studies study { get; set; }
    }
}
