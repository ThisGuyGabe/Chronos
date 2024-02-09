using Terraria;
using Terraria.ModLoader;

namespace Chronos.Content.Buffs;

public sealed class Rampage : ModBuff {
    public sealed override string Texture => "Chronos/Assets/Textures/Buffs/Rampage";
    public override void SetStaticDefaults() {
        Main.buffNoSave[Type] = false;
    }
    public override void Update(Player player, ref int buffIndex) {
        player.GetCritChance(DamageClass.Generic) += 50;
    }
}
