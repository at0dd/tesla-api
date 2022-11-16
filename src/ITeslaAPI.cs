namespace TeslaAPI
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using global::TeslaAPI.Enumerators;
    using global::TeslaAPI.Models;
    using global::TeslaAPI.Models.Response;
    using global::TeslaAPI.Models.Users;
    using global::TeslaAPI.Models.Vehicles;

    /// <summary>
    /// The interface for making API requests to the Tesla API.
    /// </summary>
    public interface ITeslaAPI
    {
        /// <summary>
        /// Exchange an authorization code for a bearer token.
        /// This is part of the standard OAuth 2.0 Authorization Code exchange.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="authorizationCode">The authorization code from the previous OAuth request.</param>
        /// <param name="codeVerifier">The code verifier string generated previously.</param>
        /// <returns>Returns a <see cref="TeslaBearerToken"/>.</returns>
        public Task<TeslaBearerToken> GetBearerTokenAsync(HttpClient client, string authorizationCode, string codeVerifier);

        /// <summary>
        /// Exchange a bearer token for an access token.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="bearerToken">The generated bearer token.</param>
        /// <returns>Returns a <see cref="TeslaAccessToken"/>.</returns>
        public Task<TeslaAccessToken> GetAccesTokenAsync(HttpClient client, string clientID, string clientSecret, string bearerToken);

        /// <summary>
        /// Authenticate with the Tesla API via email address and password to get an access token.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>Returns a <see cref="TeslaAccessToken"/>.</returns>
        [Obsolete("This method will be deprecated as Tesla switches over to OAuth.")]
        public Task<TeslaAccessToken> GetAccessTokenAsync(HttpClient client, string clientID, string clientSecret, string email, string password);

        /// <summary>
        /// Refresh an access token.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="refreshToken">The refresh token from a prior authentication.</param>
        /// <returns>Returns a <see cref="TeslaRefreshToken"/> with the new access token.</returns>
        public Task<TeslaRefreshToken> RefreshTokenAsync(HttpClient client, string refreshToken);

        /// <summary>
        /// Refresh an access token.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="refreshToken">The exising refresh token.</param>
        /// <returns>Returns a new <see cref="TeslaAccessToken"/>.</returns>
        [Obsolete("This method will be deprecated as Tesla switches over to OAuth.")]
        public Task<TeslaAccessToken> RefreshTokenAsync(HttpClient client, string clientID, string clientSecret, string refreshToken);

        /// <summary>
        /// Get the current user's information.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <returns>Returns the current user.</returns>
        public Task<User> GetMe(HttpClient client);

        /// <summary>
        /// This endpoint is a mystery, it returns what appears to be base64 encoded strings.
        /// When decoded it has a bunch of jibberish and then two certificates and some readable strings, and what appears to be a hash of something.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <returns>Returns the user's vault profile.</returns>
        public Task<VaultProfile> GetUserVaultProfile(HttpClient client);

        /// <summary>
        /// Get the feature configuration for the mobile app.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <returns>Returns the user's feature configuration.</returns>
        public Task<FeatureConfig> GetUserFeatureConfig(HttpClient client);

        /// <summary>
        /// Get all <see cref="Vehicle"/>s in the user's Tesla account.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <returns>Returns a list of <see cref="Vehicle"/>s.</returns>
        public Task<List<Vehicle>> GetAllVehiclesAsync(HttpClient client);

        /// <summary>
        /// Get all <see cref="Vehicle"/> by its ID.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/> to get.</param>
        /// <returns>Returns the <see cref="Vehicle"/>.</returns>
        public Task<Vehicle> GetVehicleAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Get all data for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/> to get.</param>
        /// <returns>Returns the <see cref="VehicleDataResponse"/>.</returns>
        public Task<VehicleDataResponse> GetVehicleDataAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="ChargeState"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="ChargeState"/>.</returns>
        public Task<ChargeState> GetVehicleChargeStateAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="ClimateState"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="ClimateState"/>.</returns>
        public Task<ClimateState> GetVehicleClimateStateAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="DriveState"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="DriveState"/>.</returns>
        public Task<DriveState> GetVehicleDriveStateAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="GUISettings"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="GUISettings"/>.</returns>
        public Task<GUISettings> GetVehicleGUISettingsAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="VehicleState"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="VehicleState"/>.</returns>
        public Task<VehicleState> GetVehicleStateAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="VehicleConfig"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="VehicleConfig"/>.</returns>
        public Task<VehicleConfig> GetVehicleConfigAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Gets if mobile access is enabled for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="bool"/>.</returns>
        public Task<bool> GetMobileEnabledAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Gets <see cref="NearbyChargingSitesResponse"/> for a <see cref="Vehicle"/>.
        /// Requires car software version 2018.48 or higher.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="NearbyChargingSitesResponse"/>.</returns>
        public Task<NearbyChargingSitesResponse> GetNearbyChargingSitesAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Wake up a <see cref="Vehicle"/> from a sleeping state.
        /// The API will return a response immediately, however it could take several seconds before the car is actually online and ready to receive other commands.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="Vehicle"/>.</returns>
        public Task<Vehicle> WakeUpAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Honks the horn twice.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> HonkHornAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Flash the headlights once.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> FlashLightsAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Enables keyless driving.
        /// There is a two minute window after issuing the command to start driving the car.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="password">The password for the Tesla account.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> RemoteStartAsync(HttpClient client, string vehicleID, string password);

        /// <summary>
        /// Opens or closes the primary Homelink device.
        /// The provided location must be in proximity of stored location of the Homelink device.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="latitude">The current location latitude.</param>
        /// <param name="longitude">The current location longitude.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> TriggerHomelinkAsync(HttpClient client, string vehicleID, double latitude, double longitude);

        /// <summary>
        /// Sets the maximum speed allowed when Speed Limit Mode is active.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="speedLimit">The speed limit in miles per hour. Must be between 50-90.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SpeedLimitSetMaximumAsync(HttpClient client, string vehicleID, int speedLimit);

        /// <summary>
        /// Activates Speed Limit Mode at the currently set speed.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="pin">The existing PIN, if previously set, or a new 4 digit PIN.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SpeedLimitActivateAsync(HttpClient client, string vehicleID, int pin);

        /// <summary>
        /// Deactivates Speed Limit Mode if it is currently active.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="pin">The 4 digit PIN used to activate Speed Limit Mode.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SpeedLimitDeactivateAsync(HttpClient client, string vehicleID, int pin);

        /// <summary>
        /// Clears the currently set PIN for Speed Limit Mode.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="pin">The 4 digit PIN used to activate Speed Limit Mode.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SpeedLimitClearPINAsync(HttpClient client, string vehicleID, int pin);

        /// <summary>
        /// Activates or deactivates Valet Mode.
        /// The password parameter isn't required to turn on or off Valet Mode, even with a previous PIN set.
        /// If you clear the PIN and activate Valet Mode without the parameter, you will only be able to deactivate it from your car's screen by signing into your Tesla account.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="on">T to activate, False to deactivate.</param>
        /// <param name="password">A PIN to deactivate Valet Mode.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ValetSetModeAsync(HttpClient client, string vehicleID, bool on, int? password = null);

        /// <summary>
        /// Clears the currently set PIN for Valet Mode when deactivated.
        /// A new PIN will be required when activating from the car screen.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ValetResetPINAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Turns sentry mode on or off.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="on">True to turn on, False to turn off.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SetSentryModeAsync(HttpClient client, string vehicleID, bool on);

        /// <summary>
        /// Unlocks the doors to the car. Extends the handles on the S and X.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> DoorsUnlockAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Locks the doors to the car. Retracts the handles on the S and X, if they are extended.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> DoorsLockAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Opens either the front or rear trunk. On the Model S and X, it will also close the rear trunk.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="which_trunk">Which trunk to open/close. rear and front are the only options.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ActuateTrunkAsync(HttpClient client, string vehicleID, string which_trunk);

        /// <summary>
        /// Controls the windows. Will vent or close all windows simultaneously.
        /// Latitude and longitude values must be near the current location of the car for close operation to succeed.
        /// For vent, the latitude and longitude values are ignored, and may both be 0 (which has been observed from the app itself).
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="command">What action to take with the windows. Allows the values vent and close.</param>
        /// <param name="latitude">Your current latitude.</param>
        /// <param name="longitude">Your current longitude.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> WindowControlAsync(HttpClient client, string vehicleID, string command, double latitude, double longitude);

        /// <summary>
        /// Controls the panoramic sunroof on the Model S.
        /// There were state options for open (100%), comfort (~80%), and move (combined with a percent parameter), but they have since been disabled server side.
        /// It is unknown if they will return at a later time.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="state">The amount to open the sunroof. Currently this only allows the values vent and close.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SunroofControlAsync(HttpClient client, string vehicleID, string state);

        /// <summary>
        /// Opens the charge port.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ChargingPortOpenAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// For vehicles with a motorized charge port, this closes it.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ChargingPortCloseAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// If the car is plugged in but not currently charging, this will start it charging.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ChargeStartAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// If the car is currently charging, this will stop it.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ChargeStopAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Sets the charge limit to "standard" or ~90%.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ChargeStandardAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Sets the charge limit to "max range" or 100%.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ChargeMaximumRangeAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Sets the charge limit to a custom value.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="percent">The percentage the battery will charge until.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ChargeSetLimitAsync(HttpClient client, string vehicleID, int percent);

        /// <summary>
        /// Sets the charge amps limit to a custom value.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="chargingAmps">The max amps to use during charging.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SetChargingAmpsAsync(HttpClient client, string vehicleID, int chargingAmps);

        /// <summary>
        /// Set the scheduled charge.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="enabled">True if scheduled charing should be turned on.</param>
        /// <param name="minutes">Time in minutes since midnight local time.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SetScheduledChargingAsync(HttpClient client, string vehicleID, bool enabled, int minutes);

        /// <summary>
        /// Set the scheduled departure.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="enabled">True if scheduled departure should be turned on, otherwise false.</param>
        /// <param name="departureTime">Time in minutes since midnight local time.</param>
        /// <param name="preconditioningEnabled">True if preconditioning should be turned on.</param>
        /// <param name="preconditioningWeekdaysOnly">True if preconditioning should only be turned on during weekdays.</param>
        /// <param name="offPeakChargingEnabled">True if charing should only happen during off-peak hours.</param>
        /// <param name="offPeakChargingWeekdaysOnly">True if charing should only happen during off-peak hours, only on weekdays.</param>
        /// <param name="endOffPeakTime">Time in minutes since midnight local time.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SetScheduledDepartureAsync(
            HttpClient client,
            string vehicleID,
            bool enabled,
            int departureTime,
            bool preconditioningEnabled,
            bool preconditioningWeekdaysOnly,
            bool offPeakChargingEnabled,
            bool offPeakChargingWeekdaysOnly,
            int endOffPeakTime);

        /// <summary>
        /// Start the climate control (HVAC) system. Will cool or heat automatically, depending on set temperature.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ClimateStartAutoConditioningAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Stop the climate control (HVAC) system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ClimateStopAutoConditioningAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Sets the target temperature for the climate control (HVAC) system.
        /// Despite accepting two parameters, only the driver_temp will be used to set the target temperature.
        /// The parameters are always in celsius, regardless of the region the car is in or the display settings of the car.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="driverTemperature">The desired temperature on the driver's side in celsius.</param>
        /// <param name="passengerTemperature">The desired temperature on the passenger's side in celsius.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ClimateSetTemperaturesAsync(HttpClient client, string vehicleID, double driverTemperature, double passengerTemperature);

        /// <summary>
        /// Toggles the climate controls between Max Defrost and the previous setting.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="on">True to turn on, False to turn off.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ClimateSetPreconditioningMaxAsync(HttpClient client, string vehicleID, bool on);

        /// <summary>
        /// Sets the specified seat's heater level.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="heater">The desired seat to heat. (0-5).</param>
        /// <param name="level">The desired level for the heater. (0-3).</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ClimateSetSeatHeatersAsync(HttpClient client, string vehicleID, Seat heater, int level);

        /// <summary>
        /// Turn steering wheel heater on or off.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="on">True to turn on, False to turn off.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ClimateSetSteeringWheelHeatAsync(HttpClient client, string vehicleID, bool on);

        /// <summary>
        /// Toggles the media between playing and paused. For the radio, this mutes or unmutes the audio.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> MediaTogglePlaybackAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Skips to the next track in the current playlist.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> MediaNextTrackAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Skips to the previous track in the current playlist.
        /// Does nothing for streaming from Stitcher.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> MediaPreviousTrackAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Skips to the next saved favorite in the media system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> MediaNextFavoriteAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Skips to the previous saved favorite in the media system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> MediaPreviousFavoriteAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Turns up the volume of the media system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> MediaVolumeUpAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Turns down the volume of the media system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> MediaVolumeDownAsync(HttpClient client, string vehicleID);

        /// <summary>
        /// Sends a location for the car to start navigation or play a video in theatre mode.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="value">The address or video URL to set as the navigation destination.</param>
        /// <param name="locale">The locale for the navigation request.</param>
        /// <param name="timestamp">The current UNIX timestamp.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ShareAsync(HttpClient client, string vehicleID, string value, string locale, long timestamp = default);

        /// <summary>
        /// Schedules a software update to be installed, if one is available.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="offset">How many seconds in the future to schedule the update. Set to 0 for immediate install.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SoftwareUpdateScheduleAsync(HttpClient client, string vehicleID, int offset);

        /// <summary>
        /// Cancels a software update, if one is scheduled and has not yet started.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> SoftwareUpdateCancelAsync(HttpClient client, string vehicleID);
    }
}