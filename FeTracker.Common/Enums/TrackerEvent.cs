namespace FeTracker.Common.Enums;

public enum TrackerEvent
{
    /// <summary>
    /// Something has requested the tracker reset state.
    /// </summary>
    Reset,
    /// <summary>
    /// A key item was found, used, or a reset has caused it to be not found.
    /// </summary>
    KeyItemUpdated,
    /// <summary>
    /// An objective was completed, or reset has undone the completion of the objective
    /// </summary>
    ObjectiveUpdated,
    /// <summary>
    /// The loaded rom has updated, indicating that the RomFileName, Header, and Version have all updated
    /// </summary>
    RomUpdated,
}