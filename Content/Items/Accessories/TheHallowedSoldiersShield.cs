using Terraria;
using Terraria.ID;
using Chronos.Common.Players;
using Chronos.Core;

namespace Chronos.Content.Items.Accessories; 
public class TheHallowedSoldiersShield : BaseItem
{
    public override string Texture => "Chronos/Assets/Textures/Missing";

    public override void SetDefaults() {
        Item.width = 18;
        Item.height = 18;
        Item.value = 10000;
        Item.rare = ItemRarityID.Cyan;
        Item.accessory = true;
        Item.defense = 10;
    }

    public static void ResetEffects(Player player) {
        ChronosPlayer p = player.GetModPlayer<ChronosPlayer>();
        p.flameThrower = false;
    }

    public override void UpdateAccessory(Player player, bool hideVisual) {
        player.statLifeMax2 = player.statLifeMax2 * 3 / 2;
        player.AddBuff(BuffID.ShadowDodge, -1);
        player.accRunSpeed = 11f;
        player.moveSpeed += 0.07f;
        player.GetModPlayer<ChronosPlayer>().chromeThrower = true;
    }
}