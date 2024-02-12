using FeTracker.Common.Enums;

namespace FeTracker.Common.Interfaces
{
    public interface IClickable
    {
        /// <summary>
        /// Returns the css class that should represent the icon
        /// </summary>
        string Class { get; }
        /// <summary>
        /// Returns the expected filename of the image
        /// </summary>
        string FileName { get; }
        /// <summary>
        /// Returns a readable name/description of the icon
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Handles updating internal state of the class
        /// </summary>
        IconState HandleClick();
    }
}
