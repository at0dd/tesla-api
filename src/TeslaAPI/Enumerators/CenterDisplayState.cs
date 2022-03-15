namespace TeslaAPI.Enumerators
{
    /// <summary>
    /// The CenterDisplayState enumerator for the VehicleState.
    /// </summary>
    public enum CenterDisplayState
    {
        /// <summary>
        /// Off
        /// </summary>
        Off = 0,

        /// <summary>
        /// On, Standby, or Camp Mode
        /// </summary>
        NormalOn = 2,

        /// <summary>
        /// On, Charging Screen
        /// </summary>
        ChargingScreen = 3,

        /// <summary>
        /// On
        /// </summary>
        On = 4,

        /// <summary>
        /// On, Big Charging Screen
        /// </summary>
        BigChargingScreen = 5,

        /// <summary>
        /// Ready to Unlock
        /// </summary>
        ReadyToUnlock = 6,

        /// <summary>
        /// Sentry Mode
        /// </summary>
        SentryMode = 7,

        /// <summary>
        /// Dog Mode
        /// </summary>
        DogMode = 8,

        /// <summary>
        /// Media
        /// </summary>
        Media = 9,
    }
}