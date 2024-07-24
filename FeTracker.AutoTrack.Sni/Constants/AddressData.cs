using FeTracker.AutoTrack.Sni.Models;

namespace FeTracker.AutoTrack.Sni.Constants
{
    public class AddressData
    {
        public const uint METADATA_LENGTH = 0x1FF000;
        public const uint METADATA_START = 0x1FF004;
        public static readonly MemoryAddress FOUND_KEY_ITEMS = new() { Address = 0xF51500, Size = 3 };
        public static readonly MemoryAddress USED_KEY_ITEMS = new() { Address = 0xF51503, Size = 3 };
        public static readonly MemoryAddress COMPLETED_OBJECTIVES = new() { Address = 0xF51503, Size = 3 };
    }
}
