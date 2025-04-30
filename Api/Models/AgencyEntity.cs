using Azure;
using Azure.Data.Tables;
using MuneebAkhterWeb.Shared;

namespace Api.Models;

public class AgencyEntity : ITableEntity
{
    public AgencyEntity() { }

    public string Regulations { get; set; } = "";
    public double RegulationSizeMb { get; set; }
    public DateTimeOffset LastUpdated { get; set; }

    public string PartitionKey { get; set; } = default!;
    public string RowKey { get; set; } = default!;
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public AgencyData ToAgencyData() => new()
    {
        AgencyName = RowKey,
        RegulationsList = Regulations,
        RegulationSizeMb = RegulationSizeMb,
        LastUpdated = LastUpdated.UtcDateTime
    };
}
