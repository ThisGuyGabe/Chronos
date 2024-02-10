using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chronos.Content.Buffs;

public sealed class Cooldown : ModBuff {
    public sealed override string Texture => "Chronos/Assets/Textures/Buffs/Cooldown";
    public override void SetStaticDefaults() {
        Main.buffNoTimeDisplay[Type] = false;
        Main.debuff[Type] = true;
        Main.buffNoSave[Type] = false;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }
}
