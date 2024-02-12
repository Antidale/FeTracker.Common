namespace FeTracker.AutoTrack.Sni.Constants
{
    public class AddressData
    {
        public const uint METADATA_LENGTH = 0x1FF000;
        public const uint METADATA_START = 0x1FF004;
        public static readonly (uint Address, uint Size) FOUND_KEY_ITEMS = (0xF51500, 3);
        public static readonly (uint Address, uint Size) USED_KEY_ITEMS = (0xF51503, 3);
        public static readonly (uint Address, uint Size) COMPLETED_OBJECTIVES = (0xF51503, 3);
    }
}
