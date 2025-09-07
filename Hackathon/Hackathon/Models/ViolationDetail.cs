using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("violation_details")]
public class ViolationDetail
{
    [Column("id")]
    public long Id { get; set; }
    [Column("violation_id")]
    public long ViolationId { get; set; }
    [Column("scanned_app_id")]
    public long ScannedAppId { get; set; }

    public Violation? Violation { get; set; }
    public ScannedApplication? ScannedApplication { get; set; }
}
