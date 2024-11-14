using DDSS_IntroSkip.Components;
using Il2Cpp;
using System.Collections;
using UnityEngine;

namespace DDSS_IntroSkip.Utils
{
    internal static class Extensions
    {
        internal static Coroutine StartCoroutine<T>(this T behaviour, IEnumerator enumerator)
            where T : MonoBehaviour
            => behaviour.StartCoroutine(
                new Il2CppSystem.Collections.IEnumerator(
                new ManagedEnumerator(enumerator).Pointer));

        internal static SettingAlternative FindAlternativeByKey(this Setting setting, string key)
        {
            if (setting.alternatives == null)
                return null;
            foreach (var alternative in setting.alternatives)
                if (alternative.key == key)
                    return alternative;
            return null;
        }
    }
}
