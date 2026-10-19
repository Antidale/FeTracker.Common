using FeTracker.Common.Models;

namespace FeTracker.Common.RazorComponents.Extensions;

public static class StatePropertyChangedArgsExtensions
{
    extension(StatePropertyChangedArgs s)
    {
        public bool IsFlagsUpdate()
        {
            return s.PropertyName == nameof(AppStateBase.Flags)
                && s.Value?.GetType() == typeof(Flags);
        }

        public bool IsVersionUpdate()
        {
            return s.PropertyName == nameof(AppStateBase.Version)
                && s.Value?.GetType() == typeof(FeVersion);
        }
    }
}
