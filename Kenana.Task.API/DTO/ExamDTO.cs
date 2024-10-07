using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examination.Kenan.DTO
{
    public class ExamDTO
    {

        public int? Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public int? TeacherId { get; set; }
        public DateTime DateOfExam { get; set; }
    }
}
