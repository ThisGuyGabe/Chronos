using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Chronos.Content.Buffs;

public class Cavities : ModBuff
{
    public override string Texture => "Chronos/Assets/Buffs/Cavities";

    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
    }
}
public class CavitiesNPC : GlobalNPC
{
    public override void DrawEffects(NPC npc, ref Color drawColor)
    {
        if (npc.HasBuff<Cavities>())
        {
            drawColor = Color.Gray;
        }
    }
    public override void HitEffect(NPC npc, NPC.HitInfo hit)
    {
        if (npc.HasBuff<Cavities>())
        {
            hit.Damage += 50;
        }
    }
}