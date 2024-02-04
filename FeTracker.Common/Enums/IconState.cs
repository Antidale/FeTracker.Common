namespace FeTracker.Common.Enums
{
    public enum IconState
    {
        /// <summary>
        /// Indicates the icon is in the default state.
        /// </summary>
        Gray = 0,
        /// <summary>
        /// Indicates the icon should be in color. E.G. Key item is found, character is in the party, boss seen/defeated 
        /// </summary>
        Color = 1,
        /// <summary>
        /// Indicates that the Key Item has been used
        /// </summary>
        Check = 2,
        /// <summary>
        /// Indicates that the charater has been dismissed from the party.
        /// </summary>
        Rejected = 3,
    }
}
