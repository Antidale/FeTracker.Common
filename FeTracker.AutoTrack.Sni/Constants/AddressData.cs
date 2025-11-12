using FeTracker.AutoTrack.Sni.Models;

namespace FeTracker.AutoTrack.Sni.Constants
{
    public class AddressData
    {
        public static readonly MemoryAddress Metadata = new() { Address = 0x1FF000, Size = 4 };
        /// <summary>
        /// The size of this document comes from reading the Metadata
        /// </summary>
        public static readonly MemoryAddress JsonDocument = new() { Address = 0x1FF004, Size = 0 };
        public static readonly MemoryAddress FOUND_KEY_ITEMS = new() { Address = 0xF51500, Size = 3 };
        public static readonly MemoryAddress USED_KEY_ITEMS = new() { Address = 0xF51503, Size = 3 };
        public static readonly MemoryAddress COMPLETED_OBJECTIVES = new() { Address = 0xF51503, Size = 3 };
    }
}
