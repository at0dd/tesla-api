namespace Tests.Unit;

using Newtonsoft.Json.Linq;
using TeslaAPI;
using TeslaAPI.Enumerators;
using Tests.Support;

/// <summary>
/// Checks the HTTP request every API method sends, against a stub handler instead of the Tesla API.
/// </summary>
public class RequestTests
{
    private const string Auth = "https://auth.tesla.com/oauth2/v3";
    private const string Owner = "https://owner-api.teslamotors.com";
    private const string Api = Owner + "/api/1";
    private const string Vehicle = Api + "/vehicles/123";
    private const string Command = Vehicle + "/command";
    private const string Site = Api + "/energy_sites/456";

    private static readonly HttpMethod Get = HttpMethod.Get;
    private static readonly HttpMethod Post = HttpMethod.Post;

    public static IEnumerable<Func<EndpointCase>> Endpoints()
    {
#pragma warning disable CS0618 // Obsolete endpoints still send requests, so they are still checked.
#pragma warning disable SA1117, SA1515 // One row per call reads better as a table.
        EndpointCase[] cases =
        [
            // Authentication
            new("GetBearerToken", (api, c) => api.GetBearerTokenAsync(c, "code", "verifier"), Post, $"{Auth}/token",
                """{"grant_type":"authorization_code","client_id":"ownerapi","code":"code","code_verifier":"verifier","redirect_uri":"https://auth.tesla.com/void/callback"}"""),
            new("GetAccessToken", (api, c) => api.GetAccessTokenAsync(c, "id", "secret", "bearer"), Post, $"{Owner}/oauth/token",
                """{"grant_type":"urn:ietf:params:oauth:grant-type:jwt-bearer","client_id":"id","client_secret":"secret"}"""),
            new("RefreshToken", (api, c) => api.RefreshTokenAsync(c, "refresh"), Post, $"{Auth}/token",
                """{"grant_type":"refresh_token","client_id":"ownerapi","refresh_token":"refresh","scope":"openid email offline_access"}"""),

            // Users
            new("GetMe", (api, c) => api.GetMeAsync(c), Get, $"{Api}/users/me"),
            new("GetUserVaultProfile", (api, c) => api.GetUserVaultProfileAsync(c), Get, $"{Api}/users/vault_profile"),
            new("GetUserFeatureConfig", (api, c) => api.GetUserFeatureConfigAsync(c), Get, $"{Api}/users/feature_config"),
            new("UpdateUserKeys", (api, c) => api.UpdateUserKeysAsync(c, "key", "name", "model"), Post, $"{Api}/users/keys",
                """{"kind":"mobile_device","public_key":"key","name":"name","model":"model"}""", """{"response":true}"""),

            // Products
            new("GetAllVehicles", (api, c) => api.GetAllVehiclesAsync(c), Get, $"{Api}/vehicles"),
            new("GetVehicle", (api, c) => api.GetVehicleAsync(c, "123"), Get, Vehicle),
            new("GetEnergyProducts", (api, c) => api.GetEnergyProductsAsync(c), Get, $"{Api}/products"),
            new("RequestTripPlan", (api, c) => api.RequestTripPlanAsync(c, "trim", "type", "dest", "orig", 0.5, "vin"), Post, $"{Owner}/trip-planner/api/v1/tripplan",
                """{"car_trim":"trim","car_type":"type","destination":"dest","origin":"orig","origin_soe":0.5,"vin":"vin"}"""),

            // Vehicle state
            new("GetVehicleData", (api, c) => api.GetVehicleDataAsync(c, "123"), Get,
                $"{Vehicle}/vehicle_data?endpoints=charge_state%3Bclimate_state%3Bclosures_state%3Bdrive_state%3Bgui_settings%3Blocation_data%3Bvehicle_config%3Bvehicle_state%3Bvehicle_data_combo"),
            new("GetMobileEnabled", (api, c) => api.GetMobileEnabledAsync(c, "123"), Get, $"{Vehicle}/mobile_enabled", ResponseJson: """{"response":true}"""),
            new("GetNearbyChargingSites", (api, c) => api.GetNearbyChargingSitesAsync(c, "123"), Get, $"{Vehicle}/nearby_charging_sites"),
            new("GetReleaseNotes", (api, c) => api.GetReleaseNotesAsync(c, "123"), Get, $"{Vehicle}/release_notes"),
            new("GetReleaseNotesStaged", (api, c) => api.GetReleaseNotesAsync(c, "123", true), Get, $"{Vehicle}/release_notes?staged=true"),

            // Vehicle commands
            new("WakeUp", (api, c) => api.WakeUpAsync(c, "123"), Post, $"{Vehicle}/wake_up"),
            new("HonkHorn", (api, c) => api.HonkHornAsync(c, "123"), Post, $"{Command}/honk_horn"),
            new("FlashLights", (api, c) => api.FlashLightsAsync(c, "123"), Post, $"{Command}/flash_lights"),
            new("RemoteStart", (api, c) => api.RemoteStartAsync(c, "123"), Post, $"{Command}/remote_start_drive"),
            new("TriggerHomelink", (api, c) => api.TriggerHomelinkAsync(c, "123", 40.5, -74.25), Post, $"{Command}/trigger_homelink",
                """{"lat":40.5,"lon":-74.25}"""),
            new("SpeedLimitSetMaximum", (api, c) => api.SpeedLimitSetMaximumAsync(c, "123", 65), Post, $"{Command}/speed_limit_set_limit", """{"limit_mph":65}"""),
            new("SpeedLimitActivate", (api, c) => api.SpeedLimitActivateAsync(c, "123", 1234), Post, $"{Command}/speed_limit_activate", """{"pin":1234}"""),
            new("SpeedLimitDeactivate", (api, c) => api.SpeedLimitDeactivateAsync(c, "123", 1234), Post, $"{Command}/speed_limit_deactivate", """{"pin":1234}"""),
            new("SpeedLimitClearPIN", (api, c) => api.SpeedLimitClearPINAsync(c, "123", 1234), Post, $"{Command}/speed_limit_clear_pin", """{"pin":1234}"""),
            new("ValetSetMode", (api, c) => api.ValetSetModeAsync(c, "123", true, 1234), Post, $"{Command}/set_valet_mode", """{"on":true,"password":1234}"""),
            new("ValetSetModeWithoutPassword", (api, c) => api.ValetSetModeAsync(c, "123", false), Post, $"{Command}/set_valet_mode", """{"on":false}"""),
            new("ValetResetPIN", (api, c) => api.ValetResetPINAsync(c, "123"), Post, $"{Command}/reset_valet_pin"),
            new("SetSentryMode", (api, c) => api.SetSentryModeAsync(c, "123", true), Post, $"{Command}/set_sentry_mode", """{"on":true}"""),
            new("DoorsUnlock", (api, c) => api.DoorsUnlockAsync(c, "123"), Post, $"{Command}/door_unlock"),
            new("DoorsLock", (api, c) => api.DoorsLockAsync(c, "123"), Post, $"{Command}/door_lock"),
            new("ActuateTrunk", (api, c) => api.ActuateTrunkAsync(c, "123", "rear"), Post, $"{Command}/actuate_trunk", """{"which_trunk":"rear"}"""),
            new("WindowControl", (api, c) => api.WindowControlAsync(c, "123", "vent", 40.5, -74.25), Post, $"{Command}/window_control",
                """{"command":"vent","lat":40.5,"lon":-74.25}"""),
            new("SunroofControl", (api, c) => api.SunroofControlAsync(c, "123", "vent"), Post, $"{Command}/sun_roof_control", """{"state":"vent"}"""),

            // Charging
            new("ChargingPortOpen", (api, c) => api.ChargingPortOpenAsync(c, "123"), Post, $"{Command}/charge_port_door_open"),
            new("ChargingPortClose", (api, c) => api.ChargingPortCloseAsync(c, "123"), Post, $"{Command}/charge_port_door_close"),
            new("ChargeStart", (api, c) => api.ChargeStartAsync(c, "123"), Post, $"{Command}/charge_start"),
            new("ChargeStop", (api, c) => api.ChargeStopAsync(c, "123"), Post, $"{Command}/charge_stop"),
            new("ChargeStandard", (api, c) => api.ChargeStandardAsync(c, "123"), Post, $"{Command}/charge_standard"),
            new("ChargeMaximumRange", (api, c) => api.ChargeMaximumRangeAsync(c, "123"), Post, $"{Command}/charge_max_range"),
            new("ChargeSetLimit", (api, c) => api.ChargeSetLimitAsync(c, "123", 80), Post, $"{Command}/set_charge_limit", """{"percent":80}"""),
            new("SetChargingAmps", (api, c) => api.SetChargingAmpsAsync(c, "123", 16), Post, $"{Command}/set_charging_amps", """{"charging_amps":16}"""),
            new("SetScheduledCharging", (api, c) => api.SetScheduledChargingAsync(c, "123", true, 120), Post, $"{Command}/set_scheduled_charging",
                """{"enable":true,"time":120}"""),
            new("SetScheduledDeparture", (api, c) => api.SetScheduledDepartureAsync(c, "123", true, 480, true, false, true, false, 360), Post, $"{Command}/set_scheduled_departure",
                """{"enable":true,"departure_time":480,"preconditioning_enabled":true,"preconditioning_weekdays_only":false,"off_peak_charging_enabled":true,"off_peak_charging_weekdays_only":false,"end_off_peak_time":360}"""),

            // Climate
            new("ClimateStartAutoConditioning", (api, c) => api.ClimateStartAutoConditioningAsync(c, "123"), Post, $"{Command}/auto_conditioning_start"),
            new("ClimateStopAutoConditioning", (api, c) => api.ClimateStopAutoConditioningAsync(c, "123"), Post, $"{Command}/auto_conditioning_stop"),
            new("ClimateSetTemperatures", (api, c) => api.ClimateSetTemperaturesAsync(c, "123", 21.5, 22.5), Post, $"{Command}/set_temps",
                """{"driver_temp":21.5,"passenger_temp":22.5}"""),
            new("ClimateSetPreconditioningMax", (api, c) => api.ClimateSetPreconditioningMaxAsync(c, "123", true), Post, $"{Command}/set_preconditioning_max", """{"on":true}"""),
            new("ClimateSetSeatHeaters", (api, c) => api.ClimateSetSeatHeatersAsync(c, "123", Seat.RearCenter, 3), Post, $"{Command}/remote_seat_heater_request",
                """{"heater":4,"level":3}"""),
            new("ClimateSetSeatCoolers", (api, c) => api.ClimateSetSeatCoolersAsync(c, "123", Seat.Passenger, 2), Post, $"{Command}/remote_seat_cooler_request",
                """{"seat_position":1,"seat_cooler_level":2}"""),
            new("ClimateSetSteeringWheelHeat", (api, c) => api.ClimateSetSteeringWheelHeatAsync(c, "123", true), Post, $"{Command}/remote_steering_wheel_heater_request", """{"on":true}"""),
            new("ClimateSetBioweaponMode", (api, c) => api.ClimateSetBioweaponModeAsync(c, "123", true), Post, $"{Command}/set_bioweapon_mode", """{"on":true}"""),
            new("SetClimateKeeperMode", (api, c) => api.SetClimateKeeperModeAsync(c, "123", ClimateKeeperMode.DogMode), Post, $"{Command}/set_climate_keeper_mode",
                """{"climate_keeper_mode":2}"""),
            new("SetAutomaticSeatClimate", (api, c) => api.SetAutomaticSeatClimateAsync(c, "123", Seat.Driver, true), Post, $"{Command}/remote_auto_seat_climate_request",
                """{"auto_seat_position":0,"auto_climate_on":true}"""),
            new("SetCabinOverheatProtectionTemperature", (api, c) => api.SetCabinOverheatProtectionTemperatureAsync(c, "123", 35), Post, $"{Command}/set_cop_temp", """{"temp":35}"""),
            new("SetCabinOverheatProtection", (api, c) => api.SetCabinOverheatProtectionAsync(c, "123", true, false), Post, $"{Command}/set_cabin_overheat_protection",
                """{"on":true,"fan_only":false}"""),

            // Media
            new("MediaTogglePlayback", (api, c) => api.MediaTogglePlaybackAsync(c, "123"), Post, $"{Command}/media_toggle_playback"),
            new("MediaNextTrack", (api, c) => api.MediaNextTrackAsync(c, "123"), Post, $"{Command}/media_next_track"),
            new("MediaPreviousTrack", (api, c) => api.MediaPreviousTrackAsync(c, "123"), Post, $"{Command}/media_prev_track"),
            new("MediaNextFavorite", (api, c) => api.MediaNextFavoriteAsync(c, "123"), Post, $"{Command}/media_next_fav"),
            new("MediaPreviousFavorite", (api, c) => api.MediaPreviousFavoriteAsync(c, "123"), Post, $"{Command}/media_prev_fav"),
            new("MediaVolumeUp", (api, c) => api.MediaVolumeUpAsync(c, "123"), Post, $"{Command}/media_volume_up"),
            new("MediaVolumeDown", (api, c) => api.MediaVolumeDownAsync(c, "123"), Post, $"{Command}/media_volume_down"),
            new("MediaAdjustVolume", (api, c) => api.MediaAdjustVolumeAsync(c, "123", 5.5), Post, $"{Command}/adjust_volume", """{"volume":5.5}"""),

            // Other commands
            new("Share", (api, c) => api.ShareAsync(c, "123", "1 Tesla Rd", "en-GB", 1700000000), Post, $"{Command}/share",
                """{"type":"share_ext_content_raw","value":{"android.intent.extra.TEXT":"1 Tesla Rd"},"locale":"en-GB","timestamp_ms":"1700000000"}"""),
            new("SoftwareUpdateSchedule", (api, c) => api.SoftwareUpdateScheduleAsync(c, "123", 60), Post, $"{Command}/schedule_software_update", """{"offset_sec":60}"""),
            new("SoftwareUpdateCancel", (api, c) => api.SoftwareUpdateCancelAsync(c, "123"), Post, $"{Command}/cancel_software_update"),
            new("TakeDriveNote", (api, c) => api.TakeDriveNodeAsync(c, "123", "note"), Post, $"{Command}/take_drivenote", """{"note":"note"}"""),
            new("SetVehicleName", (api, c) => api.SetVehicleNameAsync(c, "123", "name"), Post, $"{Command}/set_vehicle_name", """{"vehicle_name":"name"}"""),
            new("TakeScreenshot", (api, c) => api.TakeScreenshotAsync(c, "123"), Get, $"{Vehicle}/screenshot"),
            new("RemoteBoombox", (api, c) => api.RemoteBoomboxAsync(c, "123"), Post, $"{Command}/remote_boombox"),

            // Energy sites
            new("GetEnergySitePowerHistory", (api, c) => api.GetEnergySitePowerHistoryAsync(c, "456"), Get, $"{Site}/history?kind=power"),
            new("GetEnergySiteEnergyHistory", (api, c) => api.GetEnergySiteEnergyHistoryAsync(c, "456", "day"), Get, $"{Site}/history?kind=energy&period=day"),
            new("GetEnergySitePowerCalendarHistory", (api, c) => api.GetEnergySitePowerCalendarHistoryAsync(c, "456", "2024-01-01T00:00:00+10:00"), Get,
                $"{Site}/calendar_history?kind=power&end_date=2024-01-01T00%3A00%3A00%2B10%3A00"),
            new("GetEnergySiteEnergyCalendarHistory", (api, c) => api.GetEnergySiteEnergyCalendarHistoryAsync(c, "456", "week", "2024-01-01T00:00:00-07:00"), Get,
                $"{Site}/calendar_history?kind=energy&period=week&end_date=2024-01-01T00%3A00%3A00-07%3A00"),
            new("GetEnergySiteEnergyCalendarHistoryWithInterval", (api, c) => api.GetEnergySiteEnergyCalendarHistoryAsync(c, "456", "day", "2024-01-01T00:00:00-07:00", "15m"), Get,
                $"{Site}/calendar_history?kind=energy&period=day&end_date=2024-01-01T00%3A00%3A00-07%3A00&interval=15m"),
            new("GetEnergySiteBackupTimeRemaining", (api, c) => api.GetEnergySiteBackupTimeRemainingAsync(c, "456"), Get, $"{Site}/backup_time_remaining"),
            new("GetEnergySiteLiveStatus", (api, c) => api.GetEnergySiteLiveStatusAsync(c, "456"), Get, $"{Site}/live_status"),
            new("GetEnergySiteStatus", (api, c) => api.GetEnergySiteStatusAsync(c, "456"), Get, $"{Site}/site_status"),
            new("GetEnergySiteInfo", (api, c) => api.GetEnergySiteInfoAsync(c, "456"), Get, $"{Site}/site_info"),
            new("GetTariffs", (api, c) => api.GetTariffsAsync(c), Get, $"{Api}/energy_sites/rate_tariffs"),
            new("GetEnergySitePrograms", (api, c) => api.GetEnergySiteProgramsAsync(c, "456"), Get, $"{Site}/programs"),
            new("GetEnergySiteTariffRate", (api, c) => api.GetEnergySiteTariffRateAsync(c, "456"), Get, $"{Site}/tariff_rate"),
        ];
#pragma warning restore SA1117, SA1515
#pragma warning restore CS0618

        return cases.Select<EndpointCase, Func<EndpointCase>>(c => () => c);
    }

    [Test]
    [MethodDataSource(nameof(Endpoints))]
    public async Task SendsExpectedRequest(EndpointCase endpoint)
    {
        (HttpClient client, StubHttpMessageHandler handler) = StubHttpMessageHandler.CreateClient(endpoint.ResponseJson);

        await endpoint.Call(new TeslaAPI(), client);

        RecordedRequest request = handler.LastRequest;
        await Assert.That(handler.Requests).Count().IsEqualTo(1);
        await Assert.That(request.Method).IsEqualTo(endpoint.Method);
        await Assert.That(request.Uri.AbsoluteUri).IsEqualTo(new Uri(endpoint.Url).AbsoluteUri);
        await Assert.That(request.Headers["Accept"]).IsEqualTo("application/json");

        if (endpoint.Body is null)
        {
            await Assert.That(request.Body).IsNull();
        }
        else
        {
            JToken actual = JToken.Parse(request.Body!);
            JToken expected = JToken.Parse(endpoint.Body);
            await Assert.That(JToken.DeepEquals(actual, expected)).IsTrue()
                .Because($"body was {actual.ToString(Newtonsoft.Json.Formatting.None)}");
        }
    }

    [Test]
    public async Task EveryApiMethodHasARequestCase()
    {
        int apiMethods = typeof(ITeslaAPI).GetMethods().Length;
        int distinctCalls = Endpoints().Select(f => f().Name)
            .Count(name => !name.EndsWith("WithoutPassword", StringComparison.Ordinal) && !name.EndsWith("WithInterval", StringComparison.Ordinal) && !name.EndsWith("Staged", StringComparison.Ordinal));

        await Assert.That(distinctCalls).IsEqualTo(apiMethods);
    }
}
