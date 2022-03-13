namespace TeslaAPI
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using global::TeslaAPI.Enumerators;
    using global::TeslaAPI.Models;
    using global::TeslaAPI.Models.Response;
    using Newtonsoft.Json;

    /// <summary>
    /// The TeslaClient interface.
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
        [Obsolete("This method will be depreciated as Tesla switches over to OAuth.")]
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
        [Obsolete("This method will be depreciated as Tesla switches over to OAuth.")]
        public Task<TeslaAccessToken> RefreshTokenAsync(HttpClient client, string clientID, string clientSecret, string refreshToken);

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
        /// Sets the maximum charge current limit.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="maximumCurrent">The maximum current used to charge the battery.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public Task<CommandResponse> ChargeSetMaximumCurrentAsync(HttpClient client, string vehicleID, int maximumCurrent);

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

        public Task<CommandResponse> ChargeSetMaximumCurrentAsync(HttpClient client, string vehicleID, int maximumCurrent)
        {
            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "charging_amps", maximumCurrent.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_charging_amps", body: body);
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

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
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
