namespace Tesla.API
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Tesla.API.Enumerators;
    using Tesla.API.Models;
    using Tesla.API.Models.Response;

    /// <summary>
    /// The TeslaClient class.
    /// </summary>
    public class TeslaAPI : ITeslaAPI
    {
        private readonly string _authenticationBaseUrl = "https://auth.tesla.com/oauth2/v3";
        private readonly string _ownerApiBaseUrl = "https://owner-api.teslamotors.com";
        private readonly string _apiV1 = "/api/1";

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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_authenticationBaseUrl}/token", body: body);
            return SendRequestAsync<TeslaBearerToken>(client, request);
        }

        /// <inheritdoc/>
        public Task<TeslaAccessToken> GetAccesTokenAsync(HttpClient client, string clientID, string clientSecret, string bearerToken)
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token", headers: headers, body: body);
            return SendRequestAsync<TeslaAccessToken>(client, request);
        }

        /// <inheritdoc/>
        public Task<TeslaAccessToken> GetAccessTokenAsync(HttpClient client, string clientID, string clientSecret, string email, string password)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "grant_type", "password" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
                { "email", email },
                { "password", password },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token?grant_type=password", body: body);
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_authenticationBaseUrl}/token", body: body);
            return SendRequestAsync<TeslaRefreshToken>(client, request);
        }

        /// <inheritdoc/>
        public Task<TeslaAccessToken> RefreshTokenAsync(HttpClient client, string clientID, string clientSecret, string refreshToken)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "grant_type", "refresh_token" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
                { "refresh_token", refreshToken },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token?grant_type=refresh_token", body: body);
            return SendRequestAsync<TeslaAccessToken>(client, request);
        }

        /// <inheritdoc/>
        public Task<List<Vehicle>> GetAllVehiclesAsync(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles");
            return SendRequestResponseListUnwrapAsync<Vehicle>(client, request);
        }

        /// <inheritdoc/>
        public Task<Vehicle> GetVehicleAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}");
            return SendRequestResponseUnwrapAsync<Vehicle>(client, request);
        }

        /// <inheritdoc/>
        public Task<VehicleDataResponse> GetVehicleDataAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/vehicle_data");
            return SendRequestResponseUnwrapAsync<VehicleDataResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<ChargeState> GetVehicleChargeStateAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/charge_state");
            return SendRequestResponseUnwrapAsync<ChargeState>(client, request);
        }

        /// <inheritdoc/>
        public Task<ClimateState> GetVehicleClimateStateAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/climate_state");
            return SendRequestResponseUnwrapAsync<ClimateState>(client, request);
        }

        /// <inheritdoc/>
        public Task<DriveState> GetVehicleDriveStateAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/drive_state");
            return SendRequestResponseUnwrapAsync<DriveState>(client, request);
        }

        /// <inheritdoc/>
        public Task<GUISettings> GetVehicleGUISettingsAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/gui_settings");
            return SendRequestResponseUnwrapAsync<GUISettings>(client, request);
        }

        /// <inheritdoc/>
        public Task<VehicleState> GetVehicleStateAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/vehicle_state");
            return SendRequestResponseUnwrapAsync<VehicleState>(client, request);
        }

        /// <inheritdoc/>
        public Task<VehicleConfig> GetVehicleConfigAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/vehicle_config");
            return SendRequestResponseUnwrapAsync<VehicleConfig>(client, request);
        }

        /// <inheritdoc/>
        public Task<bool> GetMobileEnabledAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/mobile_enabled");
            return SendRequestResponseUnwrapAsync<bool>(client, request);
        }

        /// <inheritdoc/>
        public Task<NearbyChargingSitesResponse> GetNearbyChargingSitesAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/nearby_charging_sites");
            return SendRequestResponseUnwrapAsync<NearbyChargingSitesResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<Vehicle> WakeUpAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/wake_up");
            return SendRequestResponseUnwrapAsync<Vehicle>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> HonkHornAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/honk_horn");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> FlashLightsAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/flash_lights");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> RemoteStartAsync(HttpClient client, string vehicleID, string password)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "password", password },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/remote_start_drive", body: body);
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/trigger_homelink", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitSetMaximumAsync(HttpClient client, string vehicleID, int speedLimit)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "limit_mph", speedLimit.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/speed_limit_set_limit", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitActivateAsync(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/speed_limit_activate", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitDeactivateAsync(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/speed_limit_deactivate", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitClearPINAsync(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/speed_limit_clear_pin", body: body);
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_valet_mode", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ValetResetPINAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/reset_valet_pin");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetSentryModeAsync(HttpClient client, string vehicleID, bool on)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_sentry_mode");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> DoorsUnlockAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/door_unlock");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> DoorsLockAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/door_lock");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ActuateTrunkAsync(HttpClient client, string vehicleID, string which_trunk)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "which_trunk", which_trunk },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/actuate_trunk", body: body);
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/window_control", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SunroofControlAsync(HttpClient client, string vehicleID, string state)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "state", state },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/sun_roof_control", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargingPortOpenAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_port_door_open");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargingPortCloseAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_port_door_close");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStartAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_start");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStopAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_stop");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStandardAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_standard");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeMaximumRangeAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_max_range");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeSetLimitAsync(HttpClient client, string vehicleID, int percent)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "percent", percent.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_charge_limit", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetChargingAmpsAsync(HttpClient client, string vehicleID, int chargingAmps)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "charging_amps", chargingAmps.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_charging_amps", body: body);
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_scheduled_charging", body: body);
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_scheduled_departure", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateStartAutoConditioningAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/auto_conditioning_start");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateStopAutoConditioningAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/auto_conditioning_stop");
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_temps", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetPreconditioningMaxAsync(HttpClient client, string vehicleID, bool on)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_preconditioning_max", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetSeatHeatersAsync(HttpClient client, string vehicleID, Seat heater, int level)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "heater", heater.ToString() },
                { "level", level.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/remote_seat_heater_request", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetSteeringWheelHeatAsync(HttpClient client, string vehicleID, bool on)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/remote_steering_wheel_heater_request", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaTogglePlaybackAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_toggle_playback");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaNextTrackAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_next_track");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaPreviousTrackAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_prev_track");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaNextFavoriteAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_next_fav");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaPreviousFavoriteAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_prev_fav");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaVolumeUpAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_volume_up");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaVolumeDownAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_volume_down");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ShareAsync(HttpClient client, string vehicleID, string value, string locale, long timestamp = default)
        {
            if (timestamp == default)
            {
                timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            }

            Dictionary<string, object> shareValue = new Dictionary<string, object>
            {
                { "android.intent.extra.TEXT", value },
            };

            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "type", "share_ext_content_raw" },
                { "value", shareValue },
                { "locale", locale },
                { "timestamp", timestamp.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/share", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SoftwareUpdateScheduleAsync(HttpClient client, string vehicleID, int offset)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "offset", offset.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/schedule_software_update", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SoftwareUpdateCancelAsync(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/cancel_software_update");
            return SendRequestAsync<CommandResponse>(client, request);
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
            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error;
                throw new Exception(errorMessage);
            }

            string json = await response.Content.ReadAsStringAsync();

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
