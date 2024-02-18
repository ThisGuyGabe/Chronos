using Terraria.Audio;
using Terraria;
using Terraria.ModLoader;
using Chronos.Content.Items.Accessories;
using System.Linq;

namespace Chronos.Common.Global;

public class ChronosGlobalNPC : GlobalNPC
{
    public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo) {
        if (target.armor.Any(item => item.type == ModContent.ItemType<BloodstainedBulwark>())) {
            if (hurtInfo.Damage >= 30) {
                SoundEngine.PlaySound(ChronosSounds.ShieldStrongNoise, target.position);
            }
            else {
                SoundEngine.PlaySound(ChronosSounds.ShieldWeakNoise, target.position);
            }
        }
    }
}

