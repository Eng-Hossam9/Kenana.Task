using System.ComponentModel.DataAnnotations.Schema;

namespace Kenana.Task.API.DTO
{
    public class AddExamDTO
    {
        public string Name { get; set; } = null!;

        public int? TeacherId { get; set; }

        public DateTime DateOfExam { get; set; }
    }
}
