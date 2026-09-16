using FeTracker.Sni.Models;

namespace FeTracker.Sni.Constants
{
    public class AddressData
    {
        //Each randomized Free Enterprise ROM contains a small embedded JSON document describing its basic metadata. The length of this document is specified at address 0x1FF000 as a little-endian 32-bit integer, and the JSON document (encoded in utf-8) follows immediately after.    
        public static readonly MemoryAddress Metadata = new() { Address = 0x1FF000, Size = 4 };
        /// <summary>
        /// The size of this document comes from reading the Metadata.
        /// </summary>
        public static readonly MemoryAddress JsonDocument = new() { Address = 0x1FF004, Size = 0 };
        //7E:1500-1502: Found key items (1 bit per item)
        public static readonly MemoryAddress FOUND_KEY_ITEMS = new() { Address = 0xF51500, Size = 3 };
        //7E:1503-1505: Used key items (1 bit per item)
        public static readonly MemoryAddress USED_KEY_ITEMS = new() { Address = 0xF51503, Size = 3 };
        //Very not tested, but: 7E:1520-153F: Completed objectives (1 byte per objective, in the same order as in the metadata)
        public static readonly MemoryAddress COMPLETED_OBJECTIVES = new() { Address = 0xF51520, Size = 32 };
    }
}
