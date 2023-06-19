using BepInEx;
using HarmonyLib;
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

        [HarmonyPatch(typeof(NetGameSubroomsSystem), "SEND_ChangeRoomID")]
        [HarmonyPostfix]
        private static void SEND_ChangeRoomID(NetworkPlayer __0, string __1)
        {
            GameConsole.SetCollisions(false);
        }
    }
}