using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("approved_applications")]
public class ApprovedApplication
{
    [Column("id")]
    public long Id { get; set; }
    [Column("iso_document_id")]
    public long? IsoDocumentId { get; set; }
    [Column("app_name")]
    public required string AppName { get; set; }
    [Column("app_version")]
    public string? AppVersion { get; set; }
    [Column("vendor")]
    public string? Vendor { get; set; }
    [Column("category")]
    public string? Category { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public IsoDocument? IsoDocument { get; set; }
}
