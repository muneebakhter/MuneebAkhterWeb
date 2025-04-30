namespace MuneebAkhterWeb.Shared;

public class AgencyData
{
    public required string AgencyName { get; set; }
    public string? RegulationsList { get; set; }
    public double RegulationSizeMb { get; set; }
    public DateTime LastUpdated { get; set; }
}
