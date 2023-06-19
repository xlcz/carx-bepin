using BepInEx;
using HarmonyLib;
using Sfs2X.Entities;
using SyncMultiplayer;

namespace NoCollision
{
    [BepInPlugin("nc-max", "No Collision", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin No Collision is loaded!");
            Harmony.CreateAndPatchAll(typeof(Plugin));
        }

        [HarmonyPatch(typeof(SmartfoxRoomClient), "OnRoomJoined")]
        [HarmonyPostfix]
        private static void SEND_ChangeRoomID(Room room)
        {
            GameConsole.SetCollisions(false);
        }
    }
}