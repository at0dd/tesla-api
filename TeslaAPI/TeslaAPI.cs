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
        /// Authenticate with the Tesla API to get an access token.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>Returns a <see cref="TeslaAccessToken"/>.</returns>
        public TeslaAccessToken GetAccessToken(HttpClient client, string clientID, string clientSecret, string email, string password);

        /// <summary>
        /// Refresh an access token.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="clientID">The Tesla client ID.</param>
        /// <param name="clientSecret">The Tesla client secret.</param>
        /// <param name="refreshToken">The exising refresh token.</param>
        /// <returns>Returns a new <see cref="TeslaAccessToken"/>.</returns>
        public TeslaAccessToken RefreshToken(HttpClient client, string clientID, string clientSecret, string refreshToken);

        /// <summary>
        /// Get all <see cref="Vehicle"/>s in the user's Tesla account.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <returns>Returns a list of <see cref="Vehicle"/>s.</returns>
        public List<Vehicle> GetAllVehicles(HttpClient client);

        /// <summary>
        /// Get all <see cref="Vehicle"/> by its ID.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/> to get.</param>
        /// <returns>Returns the <see cref="Vehicle"/>.</returns>
        public Vehicle GetVehicle(HttpClient client, string vehicleID);

        /// <summary>
        /// Get all data for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/> to get.</param>
        /// <returns>Returns the <see cref="VehicleDataResponse"/>.</returns>
        public VehicleDataResponse GetVehicleData(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="ChargeState"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="ChargeState"/>.</returns>
        public ChargeState GetVehicleChargeState(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="ClimateState"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="ClimateState"/>.</returns>
        public ClimateState GetVehicleClimateState(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="DriveState"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="DriveState"/>.</returns>
        public DriveState GetVehicleDriveState(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="GUISettings"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="GUISettings"/>.</returns>
        public GUISettings GetVehicleGUISettings(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="VehicleState"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="VehicleState"/>.</returns>
        public VehicleState GetVehicleState(HttpClient client, string vehicleID);

        /// <summary>
        /// Get the <see cref="VehicleConfig"/> for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="VehicleConfig"/>.</returns>
        public VehicleConfig GetVehicleConfig(HttpClient client, string vehicleID);

        /// <summary>
        /// Gets if mobile access is enabled for a <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="bool"/>.</returns>
        public bool GetMobileEnabled(HttpClient client, string vehicleID);

        /// <summary>
        /// Gets <see cref="NearbyChargingSitesResponse"/> for a <see cref="Vehicle"/>.
        /// Requires car software version 2018.48 or higher.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="NearbyChargingSitesResponse"/>.</returns>
        public NearbyChargingSitesResponse GetNearbyChargingSites(HttpClient client, string vehicleID);

        /// <summary>
        /// Wake up a <see cref="Vehicle"/> from a sleeping state.
        /// The API will return a response immediately, however it could take several seconds before the car is actually online and ready to receive other commands.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns the <see cref="Vehicle"/>.</returns>
        public Vehicle WakeUp(HttpClient client, string vehicleID);

        /// <summary>
        /// Honks the horn twice.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse HorkHorn(HttpClient client, string vehicleID);

        /// <summary>
        /// Flash the headlights once.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse FlashLights(HttpClient client, string vehicleID);

        /// <summary>
        /// Enables keyless driving.
        /// There is a two minute window after issuing the command to start driving the car.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="password">The password for the Tesla account.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse RemoteStart(HttpClient client, string vehicleID, string password);

        /// <summary>
        /// Opens or closes the primary Homelink device.
        /// The provided location must be in proximity of stored location of the Homelink device.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="latitude">The current location latitude.</param>
        /// <param name="longitude">The current location longitude.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse TriggerHomelink(HttpClient client, string vehicleID, double latitude, double longitude);

        /// <summary>
        /// Sets the maximum speed allowed when Speed Limit Mode is active.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="speedLimit">The speed limit in miles per hour. Must be between 50-90.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse SpeedLimitSetMaximum(HttpClient client, string vehicleID, int speedLimit);

        /// <summary>
        /// Activates Speed Limit Mode at the currently set speed.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="pin">The existing PIN, if previously set, or a new 4 digit PIN.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse SpeedLimitActivate(HttpClient client, string vehicleID, int pin);

        /// <summary>
        /// Deactivates Speed Limit Mode if it is currently active.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="pin">The 4 digit PIN used to activate Speed Limit Mode.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse SpeedLimitDeactivate(HttpClient client, string vehicleID, int pin);

        /// <summary>
        /// Clears the currently set PIN for Speed Limit Mode.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="pin">The 4 digit PIN used to activate Speed Limit Mode.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse SpeedLimitClearPIN(HttpClient client, string vehicleID, int pin);

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
        public CommandResponse ValetSetMode(HttpClient client, string vehicleID, bool on, int? password = null);

        /// <summary>
        /// Clears the currently set PIN for Valet Mode when deactivated.
        /// A new PIN will be required when activating from the car screen.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ValetResetPIN(HttpClient client, string vehicleID);

        /// <summary>
        /// Turns sentry mode on or off.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="on">True to turn on, False to turn off.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse SetSentryMode(HttpClient client, string vehicleID, bool on);

        /// <summary>
        /// Unlocks the doors to the car. Extends the handles on the S and X.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse DoorsUnlock(HttpClient client, string vehicleID);

        /// <summary>
        /// Locks the doors to the car. Retracts the handles on the S and X, if they are extended.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse DoorsLock(HttpClient client, string vehicleID);

        /// <summary>
        /// Opens either the front or rear trunk. On the Model S and X, it will also close the rear trunk.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="which_trunk">Which trunk to open/close. rear and front are the only options.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ActuateTrunk(HttpClient client, string vehicleID, string which_trunk);

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
        public CommandResponse WindowControl(HttpClient client, string vehicleID, string command, double latitude, double longitude);

        /// <summary>
        /// Controls the panoramic sunroof on the Model S.
        /// There were state options for open (100%), comfort (~80%), and move (combined with a percent parameter), but they have since been disabled server side.
        /// It is unknown if they will return at a later time.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="state">The amount to open the sunroof. Currently this only allows the values vent and close.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse SunroofControl(HttpClient client, string vehicleID, string state);

        /// <summary>
        /// Opens the charge port.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ChargingPortOpen(HttpClient client, string vehicleID);

        /// <summary>
        /// For vehicles with a motorized charge port, this closes it.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ChargingPortClose(HttpClient client, string vehicleID);

        /// <summary>
        /// If the car is plugged in but not currently charging, this will start it charging.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ChargeStart(HttpClient client, string vehicleID);

        /// <summary>
        /// If the car is currently charging, this will stop it.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ChargeStop(HttpClient client, string vehicleID);

        /// <summary>
        /// Sets the charge limit to "standard" or ~90%.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ChargeStandard(HttpClient client, string vehicleID);

        /// <summary>
        /// Sets the charge limit to "max range" or 100%.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ChargeMaximumRange(HttpClient client, string vehicleID);

        /// <summary>
        /// Sets the charge limit to a custom value.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="percent">The percentage the battery will charge until.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ChargeSetLimit(HttpClient client, string vehicleID, int percent);

        /// <summary>
        /// Start the climate control (HVAC) system. Will cool or heat automatically, depending on set temperature.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ClimateStartAutoConditioning(HttpClient client, string vehicleID);

        /// <summary>
        /// Stop the climate control (HVAC) system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ClimateStopAutoConditioning(HttpClient client, string vehicleID);

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
        public CommandResponse ClimateSetTemperatures(HttpClient client, string vehicleID, double driverTemperature, double passengerTemperature);

        /// <summary>
        /// Toggles the climate controls between Max Defrost and the previous setting.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="on">True to turn on, False to turn off.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ClimateSetPreconditioningMax(HttpClient client, string vehicleID, bool on);

        /// <summary>
        /// Sets the specified seat's heater level.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="heater">The desired seat to heat. (0-5).</param>
        /// <param name="level">The desired level for the heater. (0-3).</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ClimateSetSeatHeaters(HttpClient client, string vehicleID, Seat heater, int level);

        /// <summary>
        /// Turn steering wheel heater on or off.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="on">True to turn on, False to turn off.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse ClimateSetSteeringWheelHeat(HttpClient client, string vehicleID, bool on);

        /// <summary>
        /// Toggles the media between playing and paused. For the radio, this mutes or unmutes the audio.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse MediaTogglePlayback(HttpClient client, string vehicleID);

        /// <summary>
        /// Skips to the next track in the current playlist.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse MediaNextTrack(HttpClient client, string vehicleID);

        /// <summary>
        /// Skips to the previous track in the current playlist.
        /// Does nothing for streaming from Stitcher.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse MediaPreviousTrack(HttpClient client, string vehicleID);

        /// <summary>
        /// Skips to the next saved favorite in the media system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse MediaNextFavorite(HttpClient client, string vehicleID);

        /// <summary>
        /// Skips to the previous saved favorite in the media system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse MediaPreviousFavorite(HttpClient client, string vehicleID);

        /// <summary>
        /// Turns up the volume of the media system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse MediaVolumeUp(HttpClient client, string vehicleID);

        /// <summary>
        /// Turns down the volume of the media system.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse MediaVolumeDown(HttpClient client, string vehicleID);

        /// <summary>
        /// Sends a location for the car to start navigation or play a video in theatre mode.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="value">The address or video URL to set as the navigation destination.</param>
        /// <param name="locale">The locale for the navigation request.</param>
        /// <param name="timestamp">The current UNIX timestamp.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse Share(HttpClient client, string vehicleID, string value, string locale, long timestamp);

        /// <summary>
        /// Schedules a software update to be installed, if one is available.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <param name="offset">How many seconds in the future to schedule the update. Set to 0 for immediate install.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse SoftwareUpdateSchedule(HttpClient client, string vehicleID, int offset);

        /// <summary>
        /// Cancels a software update, if one is scheduled and has not yet started.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to make the request with.</param>
        /// <param name="vehicleID">The ID of the <see cref="Vehicle"/>.</param>
        /// <returns>Returns a <see cref="CommandResponse"/>.</returns>
        public CommandResponse SoftwareUpdateCancel(HttpClient client, string vehicleID);
    }

    /// <summary>
    /// The TeslaClient class.
    /// </summary>
    public class TeslaAPI : ITeslaAPI
    {
        private readonly string _ownerApiBaseUrl = "https://owner-api.teslamotors.com";
        private readonly string _apiV1 = "/api/1";

        /// <inheritdoc/>
        public TeslaAccessToken GetAccessToken(HttpClient client, string clientID, string clientSecret, string email, string password)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
                { "email", email },
                { "password", password },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token?grant_type=password", body: body);
            return SendRequest<TeslaAccessToken>(client, request).Result;
        }

        /// <inheritdoc/>
        public TeslaAccessToken RefreshToken(HttpClient client, string clientID, string clientSecret, string refreshToken)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "client_id", clientID },
                { "client_secret", clientSecret },
                { "refresh_token", refreshToken },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}/oauth/token?grant_type=refresh_token", body);
            return SendRequest<TeslaAccessToken>(client, request).Result;
        }

        /// <inheritdoc/>
        public List<Vehicle> GetAllVehicles(HttpClient client)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles");
            return SendRequest<ListResponse<Vehicle>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public Vehicle GetVehicle(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}");
            return SendRequest<Response<Vehicle>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public VehicleDataResponse GetVehicleData(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/vehicle_data");
            return SendRequest<Response<VehicleDataResponse>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public ChargeState GetVehicleChargeState(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/charge_state");
            return SendRequest<Response<ChargeState>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public ClimateState GetVehicleClimateState(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/climate_state");
            return SendRequest<Response<ClimateState>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public DriveState GetVehicleDriveState(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/drive_state");
            return SendRequest<Response<DriveState>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public GUISettings GetVehicleGUISettings(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/gui_settings");
            return SendRequest<Response<GUISettings>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public VehicleState GetVehicleState(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/vehicle_state");
            return SendRequest<Response<VehicleState>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public VehicleConfig GetVehicleConfig(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/vehicle_config");
            return SendRequest<Response<VehicleConfig>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public bool GetMobileEnabled(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/mobile_enabled");
            return SendRequest<Response<bool>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public NearbyChargingSitesResponse GetNearbyChargingSites(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Get, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/data_request/nearby_charging_sites");
            return SendRequest<Response<NearbyChargingSitesResponse>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public Vehicle WakeUp(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/wake_up");
            return SendRequest<Response<Vehicle>>(client, request).Result.Data;
        }

        /// <inheritdoc/>
        public CommandResponse HorkHorn(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/honk_horn");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse FlashLights(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/flash_lights");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse RemoteStart(HttpClient client, string vehicleID, string password)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "password", password },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/remote_start_drive", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse TriggerHomelink(HttpClient client, string vehicleID, double latitude, double longitude)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "lat", latitude.ToString() },
                { "lon", longitude.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/trigger_homelink", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse SpeedLimitSetMaximum(HttpClient client, string vehicleID, int speedLimit)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "limit_mph", speedLimit.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/speed_limit_set_limit", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse SpeedLimitActivate(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/speed_limit_activate", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse SpeedLimitDeactivate(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/speed_limit_deactivate", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse SpeedLimitClearPIN(HttpClient client, string vehicleID, int pin)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "pin", pin.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/speed_limit_clear_pin", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ValetSetMode(HttpClient client, string vehicleID, bool on, int? password = null)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "on", on.ToString() },
            };

            if (password != null)
            {
                body.Add("password", password.ToString());
            }

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_valet_mode", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ValetResetPIN(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/reset_valet_pin");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse SetSentryMode(HttpClient client, string vehicleID, bool on)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_sentry_mode");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse DoorsUnlock(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/door_unlock");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse DoorsLock(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/door_lock");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ActuateTrunk(HttpClient client, string vehicleID, string which_trunk)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "which_trunk", which_trunk },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/actuate_trunk", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse WindowControl(HttpClient client, string vehicleID, string command, double latitude, double longitude)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "command", command },
                { "lat", latitude.ToString() },
                { "lon", longitude.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/window_control", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse SunroofControl(HttpClient client, string vehicleID, string state)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "state", state },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/sun_roof_control", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ChargingPortOpen(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_port_door_open");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ChargingPortClose(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_port_door_close");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ChargeStart(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_start");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ChargeStop(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_stop");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ChargeStandard(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_standard");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ChargeMaximumRange(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/charge_max_range");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ChargeSetLimit(HttpClient client, string vehicleID, int percent)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "percent", percent.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_charge_limit", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ClimateStartAutoConditioning(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/auto_conditioning_start");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ClimateStopAutoConditioning(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/auto_conditioning_stop");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ClimateSetTemperatures(HttpClient client, string vehicleID, double driverTemperature, double passengerTemperature)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "driver_temp", driverTemperature.ToString() },
                { "passenger_temp", passengerTemperature.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_temps", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ClimateSetPreconditioningMax(HttpClient client, string vehicleID, bool on)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/set_preconditioning_max", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ClimateSetSeatHeaters(HttpClient client, string vehicleID, Seat heater, int level)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "heater", heater.ToString() },
                { "level", level.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/remote_seat_heater_request", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse ClimateSetSteeringWheelHeat(HttpClient client, string vehicleID, bool on)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "on", on.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/remote_steering_wheel_heater_request", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse MediaTogglePlayback(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_toggle_playback");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse MediaNextTrack(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_next_track");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse MediaPreviousTrack(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_prev_track");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse MediaNextFavorite(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_next_fav");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse MediaPreviousFavorite(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_prev_fav");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse MediaVolumeUp(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_volume_up");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse MediaVolumeDown(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/media_volume_down");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse Share(HttpClient client, string vehicleID, string value, string locale, long timestamp)
        {
            Dictionary<string, string> shareValue = new Dictionary<string, string>
            {
                { "android.intent.extra.TEXT", value },
            };

            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "type", "share_ext_content_raw" },
                { "value", shareValue.ToString() },
                { "locale", locale },
                { "timestamp", timestamp.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/share", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse SoftwareUpdateSchedule(HttpClient client, string vehicleID, int offset)
        {
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "offset", offset.ToString() },
            };

            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/schedule_software_update", body);
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <inheritdoc/>
        public CommandResponse SoftwareUpdateCancel(HttpClient client, string vehicleID)
        {
            HttpRequestMessage request = BuildRequest(HttpMethod.Post, $"{_ownerApiBaseUrl}{_apiV1}/vehicles/{vehicleID}/command/cancel_software_update");
            return SendRequest<CommandResponse>(client, request).Result;
        }

        /// <summary>
        /// Build a <see cref="HttpRequestMessage"/> to send to the API.
        /// </summary>
        /// <param name="method">POST, GET, PUT, DELETE.</param>
        /// <param name="url">The request URL.</param>
        /// <param name="body">The request body.</param>
        /// <returns>Returns the build request message.</returns>
        private static HttpRequestMessage BuildRequest(HttpMethod method, string url, Dictionary<string, string> body = null)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url),
            };
            request.Headers.Add("Accept", "application/json");

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
        private static async Task<T> SendRequest<T>(HttpClient client, HttpRequestMessage request)
        {
            HttpResponseMessage response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()).Error;
                throw new Exception(errorMessage);
            }

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
