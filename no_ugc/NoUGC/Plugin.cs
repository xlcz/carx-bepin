using System;
using System.Collections;
using System.Collections.Generic;
using BepInEx;
using Customization;
using GameOverlay;
using HarmonyLib;
using Sfs2X.Entities;
using Steamworks.Ugc;
using SyncMultiplayer;
using UnityEngine;

namespace NoUGC
{
    [BepInPlugin("nugc-max", "No UGC", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin No UGC is loaded!");
            Harmony.CreateAndPatchAll(typeof(Plugin));
        }

        [HarmonyPatch(typeof(SteamUGCManager), "Update")]
        [HarmonyPrefix]
        private static bool Update(SteamUGCManager __instance)
        {
            Traverse.Create(__instance).Method("PopPendingPackage", new Type[0]); // Pop the package from ugcPackagesQueue
            return false; // Prevent UGC file from being loaded / downloaded
        }
    }
}