namespace TeslaAPI
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using global::TeslaAPI.Enumerators;
    using global::TeslaAPI.Exceptions;
    using global::TeslaAPI.Models;
    using global::TeslaAPI.Models.Engery;
    using global::TeslaAPI.Models.Response;
    using global::TeslaAPI.Models.TripPlanner;
    using global::TeslaAPI.Models.Users;
    using global::TeslaAPI.Models.Vehicles;
    using Newtonsoft.Json;

    /// <summary>
    /// The implementation class for making API requests to the Tesla API.
    /// </summary>
    public class TeslaAPI : ITeslaAPI
    {
        private const string AuthenticationBaseUrl = "https://auth.tesla.com/oauth2/v3";
        private const string OwnerApiBaseUrl = "https://owner-api.teslamotors.com";
        private const string ApiV1 = "/api/1";

        /* ---- AUTHENTICATION ---- */

        /// <inheritdoc/>
        public Task<TeslaBearerToken> GetBearerTokenAsync(HttpClient client, string authorizationCode, string codeVerifier)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "grant_type", "authorization_code" },
                { "client_id", "ownerapi" },
                { "code", authorizationCode },
                { "code_verifier", codeVerifier },
                { "redirect_uri", "https://auth.tesla.com/void/callback" },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{AuthenticationBaseUrl}/token", body: body);
            return SendRequestAsync<TeslaBearerToken>(client, request);
        }

        /// <inheritdoc/>
        public Task<TeslaAccessToken> GetAccessTokenAsync(HttpClient client, string clientID, string clientSecret, string bearerToken)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {bearerToken}" },
            };

            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}/oauth/token", headers: headers, body: body);
            return SendRequestAsync<TeslaAccessToken>(client, request);
        }

        /// <inheritdoc/>
        public Task<TeslaRefreshToken> RefreshTokenAsync(HttpClient client, string refreshToken)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "grant_type", "refresh_token" },
                { "client_id", "ownerapi" },
                { "refresh_token", refreshToken },
                { "scope", "openid email offline_access" },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{AuthenticationBaseUrl}/token", body: body);
            return SendRequestAsync<TeslaRefreshToken>(client, request);
        }

        /* ---- USERS ---- */

        /// <inheritdoc/>
        public Task<User> GetMeAsync(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/users/me");
            return SendRequestResponseUnwrapAsync<User>(client, request);
        }

        /// <inheritdoc/>
        public Task<VaultProfile> GetUserVaultProfileAsync(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/users/vault_profile");
            return SendRequestResponseUnwrapAsync<VaultProfile>(client, request);
        }

        /// <inheritdoc/>
        public Task<FeatureConfig> GetUserFeatureConfigAsync(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/users/feature_config");
            return SendRequestResponseUnwrapAsync<FeatureConfig>(client, request);
        }

        /// <inheritdoc/>
        public Task<bool> UpdateUserKeysAsync(HttpClient client, string publicKey, string name, string model)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "kind", "mobile_device" },
                { "public_key", publicKey },
                { "name", name },
                { "model", model },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/users/keys", body: body);
            return SendRequestResponseUnwrapAsync<bool>(client, request);
        }

        /* ---- VEHICLES ---- */

        /// <inheritdoc/>
        public Task<List<Vehicle>> GetAllVehiclesAsync(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles");
            return SendRequestResponseListUnwrapAsync<Vehicle>(client, request);
        }

        /// <inheritdoc/>
        public Task<Vehicle> GetVehicleAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}");
            return SendRequestResponseUnwrapAsync<Vehicle>(client, request);
        }

        /* ---- ENERGY PRODUCTS ---- */

        /// <inheritdoc/>
        public Task<List<EnergySite>> GetEnergyProductsAsync(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/products");
            return SendRequestResponseUnwrapAsync<List<EnergySite>>(client, request);
        }

        /* ---- TRIP PLANNER ---- */

        /// <inheritdoc/>
        public Task<Trip> RequestTripPlanAsync(HttpClient client, string carTrim, string carType, string destination, string origin, double originSOE, string vin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "car_trim", carTrim },
                { "car_type", carType },
                { "destination", destination },
                { "origin", origin },
                { "origin_soe", originSOE },
                { "vin", vin },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}/trip-planner{ApiV1}/tripplan", body: body);
            return SendRequestAsync<Trip>(client, request);
        }

        /* ---- VEHICLE ---- */
        /* --- State --- */

        /// <inheritdoc/>
        public Task<VehicleData> GetVehicleDataAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/vehicle_data?endpoints=location_data");
            return SendRequestResponseUnwrapAsync<VehicleData>(client, request);
        }

        /// <inheritdoc/>
        public Task<bool> GetMobileEnabledAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/mobile_enabled");
            return SendRequestResponseUnwrapAsync<bool>(client, request);
        }

        /// <inheritdoc/>
        public Task<NearbyChargingSites> GetNearbyChargingSitesAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/nearby_charging_sites");
            return SendRequestResponseUnwrapAsync<NearbyChargingSites>(client, request);
        }

        /// <inheritdoc/>
        public Task<ReleaseNotesResponse> GetReleaseNotesAsync(HttpClient client, string vehicleID, bool? staged = false)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/release_notes");
            return SendRequestResponseUnwrapAsync<ReleaseNotesResponse>(client, request);
        }

        /* --- Commands --- */

        /// <inheritdoc/>
        public Task<Vehicle> WakeUpAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/wake_up");
            return SendRequestResponseUnwrapAsync<Vehicle>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> HonkHornAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/honk_horn");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> FlashLightsAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/flash_lights");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> RemoteStartAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/remote_start_drive");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> TriggerHomelinkAsync(HttpClient client, string vehicleID, double latitude, double longitude)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "lat", latitude.ToString() },
                { "lon", longitude.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/trigger_homelink", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitSetMaximumAsync(HttpClient client, string vehicleID, int speedLimit)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "limit_mph", speedLimit.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/speed_limit_set_limit", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitActivateAsync(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/speed_limit_activate", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitDeactivateAsync(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/speed_limit_deactivate", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitClearPINAsync(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/speed_limit_clear_pin", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ValetSetModeAsync(HttpClient client, string vehicleID, bool on, int? password = null)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            if (password != null)
            {
                body.Add("password", password.ToString());
            }

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_valet_mode", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ValetResetPINAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/reset_valet_pin");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetSentryModeAsync(HttpClient client, string vehicleID, bool on)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_sentry_mode");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> DoorsUnlockAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/door_unlock");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> DoorsLockAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/door_lock");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ActuateTrunkAsync(HttpClient client, string vehicleID, string which_trunk)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "which_trunk", which_trunk },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/actuate_trunk", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> WindowControlAsync(HttpClient client, string vehicleID, string command, double latitude, double longitude)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "command", command },
                { "lat", latitude.ToString() },
                { "lon", longitude.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/window_control", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SunroofControlAsync(HttpClient client, string vehicleID, string state)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "state", state },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/sun_roof_control", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargingPortOpenAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/charge_port_door_open");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargingPortCloseAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/charge_port_door_close");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStartAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/charge_start");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStopAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/charge_stop");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStandardAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/charge_standard");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeMaximumRangeAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/charge_max_range");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeSetLimitAsync(HttpClient client, string vehicleID, int percent)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "percent", percent.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_charge_limit", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetChargingAmpsAsync(HttpClient client, string vehicleID, int chargingAmps)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "charging_amps", chargingAmps.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_charging_amps", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetScheduledChargingAsync(HttpClient client, string vehicleID, bool enabled, int minutes)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "enable", enabled },
                { "time", minutes },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_scheduled_charging", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetScheduledDepartureAsync(
            HttpClient client,
            string vehicleID,
            bool enabled,
            int departureTime,
            bool preconditioningEnabled,
            bool preconditioningWeekdaysOnly,
            bool offPeakChargingEnabled,
            bool offPeakChargingWeekdaysOnly,
            int endOffPeakTime)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "enable", enabled },
                { "departure_time", departureTime },
                { "preconditioning_enabled", preconditioningEnabled },
                { "preconditioning_weekdays_only", preconditioningWeekdaysOnly },
                { "off_peak_charging_enabled", offPeakChargingEnabled },
                { "off_peak_charging_weekdays_only", offPeakChargingWeekdaysOnly },
                { "end_off_peak_time", endOffPeakTime },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_scheduled_departure", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateStartAutoConditioningAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/auto_conditioning_start");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateStopAutoConditioningAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/auto_conditioning_stop");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetTemperaturesAsync(HttpClient client, string vehicleID, double driverTemperature, double passengerTemperature)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "driver_temp", driverTemperature.ToString() },
                { "passenger_temp", passengerTemperature.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_temps", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetPreconditioningMaxAsync(HttpClient client, string vehicleID, bool on)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_preconditioning_max", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetSeatHeatersAsync(HttpClient client, string vehicleID, Seat seat, int level)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "heater", seat.ToString() },
                { "level", level.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/remote_seat_heater_request", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetSeatCoolersAsync(HttpClient client, string vehicleID, Seat seat, int level)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "seat_position", seat.ToString() },
                { "seat_cooler_level", level.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/remote_seat_cooler_request", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetSteeringWheelHeatAsync(HttpClient client, string vehicleID, bool on)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/remote_steering_wheel_heater_request", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetBioweaponModeAsync(HttpClient client, string vehicleID, bool on)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_bioweapon_mode", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetClimateKeeperModeAsync(HttpClient client, string vehicleID, ClimateKeeperMode mode)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "climate_keeper_mode", mode },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_climate_keeper_mode", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetAutomaticSeatClimateAsync(HttpClient client, string vehicleID, Seat seat, bool on)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "auto_seat_position", seat },
                { "auto_climate_on", on },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/remote_auto_seat_climate_request", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetCabinOverheatProtectionTemperatureAsync(HttpClient client, string vehicleID, int temperature)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "temp", temperature },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_cop_temp", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetCabinOverheatProtectionAsync(HttpClient client, string vehicleID, bool on, bool fanOnly)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on },
                { "fan_only", fanOnly },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_cabin_overheat_protection", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaTogglePlaybackAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/media_toggle_playback");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaNextTrackAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/media_next_track");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaPreviousTrackAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/media_prev_track");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaNextFavoriteAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/media_next_fav");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaPreviousFavoriteAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/media_prev_fav");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaVolumeUpAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/media_volume_up");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaVolumeDownAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/media_volume_down");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaAdjustVolumeAsync(HttpClient client, string vehicleID, double volume)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "volume", volume },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/adjust_volume", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ShareAsync(HttpClient client, string vehicleID, string value, string? locale = "en-US", long? timestamp = null)
        {
            if (timestamp.HasValue)
            {
                timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            }

            Dictionary<string, string> shareValue = new Dictionary<string, string>
            {
                { "android.intent.extra.TEXT", value },
            };

            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "type", "share_ext_content_raw" },
                { "value", shareValue },
                { "locale", locale },
                { "timestamp", timestamp.Value.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/share", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<ScheduleSoftwareUpdateResponse> SoftwareUpdateScheduleAsync(HttpClient client, string vehicleID, int offset)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "offset", offset.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/schedule_software_update", body: body);
            return SendRequestAsync<ScheduleSoftwareUpdateResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SoftwareUpdateCancelAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/cancel_software_update");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> TakeDriveNodeAsync(HttpClient client, string vehicleID, string note)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "note", note },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/take_drivenote", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetVehicleNameAsync(HttpClient client, string vehicleID, string name)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "vehicle_name", name },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/set_vehicle_name", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<string> TakeScreenshotAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/screenshot");
            return SendRequestResponseUnwrapAsync<string>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> RemoteBoomboxAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleID}/command/remote_boombox");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /* ---- ENERGY PRODUCTS ---- */

        /// <inheritdoc/>
        public Task<EnergySitePowerHistory> GetEnergySitePowerHistoryAsync(HttpClient client, string siteID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/history?kind=power");
            return SendRequestResponseUnwrapAsync<EnergySitePowerHistory>(client, request);
        }

        /// <inheritdoc/>
        public Task<EnergySiteEnergyHistory> GetEnergySiteEnergyHistoryAsync(HttpClient client, string siteID, string period)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/history?kind=energy&period={period}");
            return SendRequestResponseUnwrapAsync<EnergySiteEnergyHistory>(client, request);
        }

        /// <inheritdoc/>
        public Task<EnergySitePowerCalendarHistory> GetEnergySitePowerCalendarHistoryAsync(HttpClient client, string siteID, string endDate)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/history?kind=power&end_date={endDate}");
            return SendRequestResponseUnwrapAsync<EnergySitePowerCalendarHistory>(client, request);
        }

        /// <inheritdoc/>
        public Task<EnergySiteEnergyCalendarHistory> GetEnergySiteEnergyCalendarHistoryAsync(HttpClient client, string siteID, string period, string endDate, string? interval = null)
        {
            string url = $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/history?kind=energy&period={period}&end_date={endDate}";
            if (!string.IsNullOrWhiteSpace(interval))
            {
                url += $"&interval={interval}";
            }

            HttpRequestMessage request = BuildRequest(HttpMethod.Get, url);
            return SendRequestResponseUnwrapAsync<EnergySiteEnergyCalendarHistory>(client, request);
        }

        /// <inheritdoc/>
        public Task<BackupTimeRemaining> GetEnergySiteBackupTimeRemainingAsync(HttpClient client, string siteID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/backup_time_remaining");
            return SendRequestResponseUnwrapAsync<BackupTimeRemaining>(client, request);
        }

        /// <inheritdoc/>
        public Task<EnergySiteLiveStatus> GetEnergySiteLiveStatusAsync(HttpClient client, string siteID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/live_status");
            return SendRequestResponseUnwrapAsync<EnergySiteLiveStatus>(client, request);
        }

        /// <inheritdoc/>
        public Task<EnergySiteStatus> GetEnergySiteStatusAsync(HttpClient client, string siteID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/site_status");
            return SendRequestResponseUnwrapAsync<EnergySiteStatus>(client, request);
        }

        /// <inheritdoc/>
        public Task<EnergySiteInfo> GetEnergySiteInfoAsync(HttpClient client, string siteID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/site_info");
            return SendRequestResponseUnwrapAsync<EnergySiteInfo>(client, request);
        }

        /// <inheritdoc/>
        public Task<List<Tariff>> GetTariffsAsync(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/rate_tariffs");
            return SendRequestResponseListUnwrapAsync<Tariff>(client, request);
        }

        /// <inheritdoc/>
        public Task<ProgramsResponse> GetEnergySiteProgramsAsync(HttpClient client, string siteID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/programs");
            return SendRequestResponseUnwrapAsync<ProgramsResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<TariffRate> GetEnergySiteTariffRateAsync(HttpClient client, string siteID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/energy_sites/{siteID}/tariff_rate");
            return SendRequestResponseUnwrapAsync<TariffRate>(client, request);
        }

        /// <summary>
        /// Build a <see cref="HttpRequestMessage"/> to send to the API.
        /// </summary>
        /// <param name="method">POST, GET, PUT, DELETE.</param>
        /// <param name="url">The request URL.</param>
        /// <param name="headers">Additional headers to add to the request.</param>
        /// <param name="body">The request body.</param>
        /// <returns>Returns the build request message.</returns>
        private static HttpRequestMessage BuildRequest(HttpMethod method, string url, Dictionary<string, string> headers = null, Dictionary<string, object> body = null)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url),
            };

            request.Headers.Add("Accept", "application/json");
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (body != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            }

            return request;
        }

        /// <summary>
        /// Send a request to the API and return the response.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="client">The <see cref="HttpClient"/> to send the request with.</param>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <returns>Returns the response <see cref="Task"/>.</returns>
        private static async Task<T> SendRequestAsync<T>(HttpClient client, HttpRequestMessage request)
        {
            HttpResponseMessage response = await client.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = JsonConvert.DeserializeObject<ErrorResponse>(json).Error;
                throw new TeslaApiRequestUnsuccessfulException(response.StatusCode, errorMessage);
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                e.Data["TeslaAPI.Response"] = json;
                throw;
            }
        }

        /// <summary>
        /// Send a request to the Tesla API - return a singular object.
        /// </summary>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="client">The <see cref="HttpClient"/> to send the request with.</param>
        /// <param name="request">The request to send.</param>
        /// <returns>Returns the request data.</returns>
        private static async Task<T> SendRequestResponseUnwrapAsync<T>(HttpClient client, HttpRequestMessage request)
        {
            Response<T> response = await SendRequestAsync<Response<T>>(client, request);
            return response.Data;
        }

        /// <summary>
        /// Send a request to the Tesla API - return a list of objects.
        /// </summary>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="client">The <see cref="HttpClient"/> to send the request with.</param>
        /// <param name="request">The request to send.</param>
        /// <returns>Returns the request data.</returns>
        private static async Task<List<T>> SendRequestResponseListUnwrapAsync<T>(HttpClient client, HttpRequestMessage request)
        {
            ListResponse<T> response = await SendRequestAsync<ListResponse<T>>(client, request);
            return response.Data;
        }
    }
}
