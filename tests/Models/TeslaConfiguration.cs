namespace Tests.Models;

public class TeslaConfiguration
{
    public const string SectionName = "Tesla";

    public string AccessToken { get; set; }

    public string VehicleID { get; set; }

    public string EnergySiteID { get; set; }
}
