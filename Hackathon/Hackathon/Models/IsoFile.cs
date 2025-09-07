using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("iso_files")]
public class IsoFile
{
    [Column("id")]
    public long Id { get; set; }
    [Column("iso_document_id")]
    public long IsoDocumentId { get; set; }
    [Column("file_path")]
    public required string FilePath { get; set; }
    [Column("file_type")]
    public string? FileType { get; set; }
    [Column("uploaded_at")]
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public IsoDocument? IsoDocument { get; set; }
}
