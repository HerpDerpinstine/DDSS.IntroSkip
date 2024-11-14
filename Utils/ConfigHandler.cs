using MelonLoader;
using UnityEngine;

namespace DDSS_IntroSkip.Utils
{
    internal static class ConfigHandler
    {
        private static MelonPreferences_Category _prefs_Category;
        internal static MelonPreferences_Entry<bool> _prefs_SkipIntro;

        internal static void Setup()
        {
            // Create Preferences Category
            _prefs_Category = MelonPreferences.CreateCategory("IntroSkip", "Intro Skip");

            // Create Preferences Entries
            _prefs_SkipIntro = CreatePref("Enabled",
                "Enabled",
                "Skips the Intro when a Match starts",
                true);
        }

        private static MelonPreferences_Entry<T> CreatePref<T>(
            string id,
            string displayName,
            string description,
            T defaultValue,
            bool isHidden = false)
            => _prefs_Category.CreateEntry(id,
                defaultValue,
                displayName,
                description,
                isHidden,
                false,
                null);
    }
}
