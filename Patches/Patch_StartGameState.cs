using DDSS_IntroSkip.Utils;
using HarmonyLib;
using Il2Cpp;
using Il2CppGameManagement.StateMachine;
using Il2CppPlayer.Lobby;
using Il2CppUMUI;
using System.Collections;
using UnityEngine;

namespace DDSS_IntroSkip.Patches
{
    [HarmonyPatch]
    internal class Patch_StartGameState
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(StartGameState), nameof(StartGameState.EnterCoroutine))]
        private static bool EnterCoroutine_Prefix(StartGameState __instance)
        {
            // Run New Coroutine
            __instance.gameManager.StartCoroutine(FixedEnterCoroutine(__instance));

            // Prevent Original
            return false;
        }

        private static IEnumerator FixedEnterCoroutine(StartGameState __instance)
        {
            // Validate Local Player Role
            while (LobbyManager.instance.GetLocalPlayer().playerRole == PlayerRole.None)
                yield return null;

            // Show Intro
            if (!ConfigHandler._prefs_SkipIntro.Value)
            {
                UIManager.instance.OpenTab("Intro");
                yield return new WaitForSeconds(7.5f);
            }

            // Close All Tabs
            UIManager.instance.CloseAllTabs();
            yield return new WaitForSeconds(0.1f);

            // Reveal Role
            UIManager.instance.OpenTab("ShowRole");
            yield return new WaitForSeconds(4f);

            // Close All Tabs
            UIManager.instance.CloseAllTabs();
            yield return new WaitForSeconds(0.1f);

            // Show HUD
            UIManager.instance.OpenTab("HUD");

            // Role Hint
            switch (LobbyManager.instance.GetLocalPlayer().playerRole)
            {
                case PlayerRole.Specialist:
                    UIManager.instance.ShowHint(
                        LocalizationManager.instance.GetLocalizedValue(
                            "You are a specialist! Your job is to complete the tasks given to you by the manager. Also, it might be a good idea to look out for the slackers in order to tell the manager!"), 
                        8f, 12f);
                    break;

                case PlayerRole.Slacker:
                    UIManager.instance.ShowHint(
                        LocalizationManager.instance.GetLocalizedValue(
                        "You are a slacker! Your job is to pointless tasks without making the manager suspicious. You can do that by avoiding the manager and not getting fired."),
                        8f, 12f);
                    break;

                case PlayerRole.Manager:
                    UIManager.instance.ShowHint(
                        LocalizationManager.instance.GetLocalizedValue(
                            "You are the manager! Your job is to figure out who the slackers are and fire them. You can do that using the whiteboard in the conference room!"), 
                        8f, 12f);
                    break;
            }

            // Firewall Hint
            UIManager.instance.ShowHint(
                LocalizationManager.instance.GetLocalizedValue(
                    "Remember to turn on the firewall on your computer! Otherwise, you might get a virus. However, slackers get viruses regardless"),
                8f, 30f);
            
            // Signal that the Match has Started
            if (__instance.gameManager.isServer)
                __instance.ChangeState(GameStates.InGame);

            // Construct Map
            MapCreator.instance.ConstructMap();

            // Break Coroutine
            yield break;
        }
    }
}
