namespace FeTracker.AutoTrack.Sni.Models
{
    public readonly struct MemoryAddress
    {
        public uint Address { get; init; }
        /// <summary>
        /// A zero size indicates that ?? what was past me thinking just stopping typing there
        /// </summary>
        public uint Size { get; init; }

    }
}
