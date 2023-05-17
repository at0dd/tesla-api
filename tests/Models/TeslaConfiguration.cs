namespace Tests.Models;

public class TeslaConfiguration
{
    public const string SectionName = "Tesla";

    public string AccessToken { get; set; } = string.Empty;

    public string VehicleID { get; set; } = string.Empty;

    public string CarTrim { get; set; } = string.Empty;

    public string CarType { get; set; } = string.Empty;

    public string VIN { get; set; } = string.Empty;
}
