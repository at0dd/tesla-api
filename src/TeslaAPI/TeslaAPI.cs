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
    using global::TeslaAPI.Models.Response;
    using Newtonsoft.Json;

    /// <summary>
    /// The implementation class for making API requests to the Tesla API.
    /// </summary>
    public class TeslaAPI : ITeslaAPI
    {
        private const string AuthenticationBaseUrl = "https://auth.tesla.com/oauth2/v3";
        private const string OwnerApiBaseUrl = "https://owner-api.teslamotors.com";
        private const string ApiV1 = "/api/1";

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
        public Task<TeslaAccessToken> GetAccesTokenAsync(HttpClient client, string clientId, string clientSecret, string bearerToken)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {bearerToken}" },
            };

            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer" },
                { "client_id", clientId },
                { "client_secret", clientSecret },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}/oauth/token", headers: headers, body: body);
            return SendRequestAsync<TeslaAccessToken>(client, request);
        }

        /// <inheritdoc/>
        public Task<TeslaAccessToken> GetAccessTokenAsync(HttpClient client, string clientId, string clientSecret, string email, string password)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "grant_type", "password" },
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "email", email },
                { "password", password },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}/oauth/token?grant_type=password", body: body);
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

        /// <inheritdoc/>
        public Task<TeslaAccessToken> RefreshTokenAsync(HttpClient client, string clientId, string clientSecret, string refreshToken)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "grant_type", "refresh_token" },
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "refresh_token", refreshToken },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}/oauth/token?grant_type=refresh_token", body: body);
            return SendRequestAsync<TeslaAccessToken>(client, request);
        }

        /// <inheritdoc/>
        public Task<List<Vehicle>> GetAllVehiclesAsync(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles");
            return SendRequestResponseListUnwrapAsync<Vehicle>(client, request);
        }

        /// <inheritdoc/>
        public Task<Vehicle> GetVehicleAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}");
            return SendRequestResponseUnwrapAsync<Vehicle>(client, request);
        }

        /// <inheritdoc/>
        public Task<VehicleDataResponse> GetVehicleDataAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/vehicle_data");
            return SendRequestResponseUnwrapAsync<VehicleDataResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<ChargeState> GetVehicleChargeStateAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/data_request/charge_state");
            return SendRequestResponseUnwrapAsync<ChargeState>(client, request);
        }

        /// <inheritdoc/>
        public Task<ClimateState> GetVehicleClimateStateAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/data_request/climate_state");
            return SendRequestResponseUnwrapAsync<ClimateState>(client, request);
        }

        /// <inheritdoc/>
        public Task<DriveState> GetVehicleDriveStateAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/data_request/drive_state");
            return SendRequestResponseUnwrapAsync<DriveState>(client, request);
        }

        /// <inheritdoc/>
        public Task<GUISettings> GetVehicleGuiSettingsAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/data_request/gui_settings");
            return SendRequestResponseUnwrapAsync<GUISettings>(client, request);
        }

        /// <inheritdoc/>
        public Task<VehicleState> GetVehicleStateAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/data_request/vehicle_state");
            return SendRequestResponseUnwrapAsync<VehicleState>(client, request);
        }

        /// <inheritdoc/>
        public Task<VehicleConfig> GetVehicleConfigAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/data_request/vehicle_config");
            return SendRequestResponseUnwrapAsync<VehicleConfig>(client, request);
        }

        /// <inheritdoc/>
        public Task<bool> GetMobileEnabledAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/data_request/mobile_enabled");
            return SendRequestResponseUnwrapAsync<bool>(client, request);
        }

        /// <inheritdoc/>
        public Task<NearbyChargingSitesResponse> GetNearbyChargingSitesAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/data_request/nearby_charging_sites");
            return SendRequestResponseUnwrapAsync<NearbyChargingSitesResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<Vehicle> WakeUpAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/wake_up");
            return SendRequestResponseUnwrapAsync<Vehicle>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> HonkHornAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/honk_horn");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> FlashLightsAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/flash_lights");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> RemoteStartAsync(HttpClient client, string vehicleId, string password)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "password", password },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/remote_start_drive", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> TriggerHomelinkAsync(HttpClient client, string vehicleId, double latitude, double longitude)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "lat", latitude.ToString() },
                { "lon", longitude.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/trigger_homelink", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitSetMaximumAsync(HttpClient client, string vehicleId, int speedLimit)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "limit_mph", speedLimit.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/speed_limit_set_limit", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitActivateAsync(HttpClient client, string vehicleId, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/speed_limit_activate", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitDeactivateAsync(HttpClient client, string vehicleId, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/speed_limit_deactivate", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SpeedLimitClearPinAsync(HttpClient client, string vehicleId, int pin)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/speed_limit_clear_pin", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ValetSetModeAsync(HttpClient client, string vehicleId, bool on, int? password = null)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            if (password != null)
            {
                body.Add("password", password.ToString());
            }

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/set_valet_mode", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ValetResetPinAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/reset_valet_pin");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetSentryModeAsync(HttpClient client, string vehicleId, bool on)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/set_sentry_mode");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> DoorsUnlockAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/door_unlock");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> DoorsLockAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/door_lock");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ActuateTrunkAsync(HttpClient client, string vehicleId, string whichTrunk)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "which_trunk", whichTrunk },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/actuate_trunk", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> WindowControlAsync(HttpClient client, string vehicleId, string command, double latitude, double longitude)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "command", command },
                { "lat", latitude.ToString() },
                { "lon", longitude.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/window_control", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SunroofControlAsync(HttpClient client, string vehicleId, string state)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "state", state },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/sun_roof_control", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargingPortOpenAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/charge_port_door_open");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargingPortCloseAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/charge_port_door_close");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStartAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/charge_start");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStopAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/charge_stop");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeStandardAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/charge_standard");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeMaximumRangeAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/charge_max_range");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ChargeSetLimitAsync(HttpClient client, string vehicleId, int percent)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "percent", percent.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/set_charge_limit", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetChargingAmpsAsync(HttpClient client, string vehicleId, int chargingAmps)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "charging_amps", chargingAmps.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/set_charging_amps", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetScheduledChargingAsync(HttpClient client, string vehicleId, bool enabled, int minutes)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "enable", enabled },
                { "time", minutes },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/set_scheduled_charging", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SetScheduledDepartureAsync(
            HttpClient client,
            string vehicleId,
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/set_scheduled_departure", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateStartAutoConditioningAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/auto_conditioning_start");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateStopAutoConditioningAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/auto_conditioning_stop");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetTemperaturesAsync(HttpClient client, string vehicleId, double driverTemperature, double passengerTemperature)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "driver_temp", driverTemperature.ToString() },
                { "passenger_temp", passengerTemperature.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/set_temps", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetPreconditioningMaxAsync(HttpClient client, string vehicleId, bool on)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/set_preconditioning_max", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetSeatHeatersAsync(HttpClient client, string vehicleId, Seat heater, int level)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "heater", heater.ToString() },
                { "level", level.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/remote_seat_heater_request", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ClimateSetSteeringWheelHeatAsync(HttpClient client, string vehicleId, bool on)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/remote_steering_wheel_heater_request", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaTogglePlaybackAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/media_toggle_playback");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaNextTrackAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/media_next_track");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaPreviousTrackAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/media_prev_track");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaNextFavoriteAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/media_next_fav");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaPreviousFavoriteAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/media_prev_fav");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaVolumeUpAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/media_volume_up");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> MediaVolumeDownAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/media_volume_down");
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> ShareAsync(HttpClient client, string vehicleId, string value, string locale, long timestamp = default)
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

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/share", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SoftwareUpdateScheduleAsync(HttpClient client, string vehicleId, int offset)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "offset", offset.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/schedule_software_update", body: body);
            return SendRequestAsync<CommandResponse>(client, request);
        }

        /// <inheritdoc/>
        public Task<CommandResponse> SoftwareUpdateCancelAsync(HttpClient client, string vehicleId)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{OwnerApiBaseUrl}{ApiV1}/vehicles/{vehicleId}/command/cancel_software_update");
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
                throw new TeslaApiRequestUnsuccessfulException(errorMessage);
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
