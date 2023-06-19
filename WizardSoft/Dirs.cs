using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WizardSoft
{
    public class Dir
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? ParentId { get; set; }
        public Dir? Parent { get; set; }
        public List<Dir>? Children { get; set; } = new();
    }
}
