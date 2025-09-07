using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("iso_documents")]
public class IsoDocument
{
    public long Id { get; set; }
    public required string Version { get; set; }
    public int Year { get; set; }
    public long? UploadedBy { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }
    public bool IsActive { get; set; }

    public User? Uploader { get; set; }
    public ICollection<IsoFile> Files { get; set; } = new List<IsoFile>();
}
