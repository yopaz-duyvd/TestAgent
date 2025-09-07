using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("iso_documents")]
public class IsoDocument
{
    [Column("id")]
    public long Id { get; set; }
    [Column("version")]
    public required string Version { get; set; }
    [Column("year")]
    public int Year { get; set; }
    [Column("uploaded_by")]
    public long? UploaderId { get; set; }
    [Column("uploaded_at")]
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    [Column("notes")]
    public string? Notes { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; }
    [Column("scanned_at")]
    public DateTime? ScannedAt { get; set; }

    public User? Uploader { get; set; }
    public ICollection<IsoFile> Files { get; set; } = new List<IsoFile>();
}
