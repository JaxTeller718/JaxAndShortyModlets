using HarmonyLib;
namespace Harmony.PlayerFeatures
{

    [HarmonyPatch(typeof(GameManager))]
    [HarmonyPatch("PlayerSpawnedInWorld")]
    public class TeleportNPCs
    {
        private static void Postfix(ClientInfo _cInfo, RespawnType _respawnReason, Vector3i _pos, int _entityId)
        {
            Entity entity;
            if (!GameManager.Instance.World.Entities.dict.TryGetValue(_entityId, out entity)) return;
            EntityPlayer entityPlayer = entity as EntityPlayer;
            if (entityPlayer == null) return;

            // Check if the player has any hired NPCs to respawn with it.
            EntityUtilities.Respawn(entityPlayer.entityId);
        }
    }
}