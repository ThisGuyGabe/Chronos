using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chronos.Content.Items.Accessories {
    public sealed class TheCursedSoldiersShield : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 10000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.defense = 10;
        }

        public static void ResetEffects(Player player)
        {
            //player.GetModPlayer<ChronosPlayer>().ichorThrower = false;
            ChronosPlayer p = player.GetModPlayer<ChronosPlayer>();
            p.ichorThrower = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = player.statLifeMax2 * 2 / 3; // It's simplified now.
            player.buffImmune[BuffID.Ichor] = true;
            player.accRunSpeed = 11f; // The player's maximum run speed with accessories
            player.moveSpeed += 0.07f; // The acceleration multiplier of the player's movement speed
            player.GetModPlayer<ChronosPlayer>().ichorThrower = true;
        }
    }
}