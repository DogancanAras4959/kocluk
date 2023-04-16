using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("exams")]
    public class Exams : BaseEntity
    {
        public Exams()
        {

        }

        [ForeignKey("study")]
        public int StudyId { get; set; }

        [ForeignKey("studies")]
        public int StudentId { get; set; }

        [ForeignKey("teacher")]
        public int UserId { get; set; }

        public int Point { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime FinishTime { get; set; }

        public bool IsDoing { get; set; }

        public Studies study { get; set; }
        public Students student { get; set; }
        public Users teacher { get; set; }
    }
}
