using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chronos.Content.Items.Accessories {
    public sealed class TheCorruptedSoldiersShield : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.defense = 10;
        }

        public static void ResetEffects(Player player)
        {
            ChronosPlayer p = player.GetModPlayer<ChronosPlayer>();
            p.flameThrower = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = player.statLifeMax2 * 2 / 3;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.accRunSpeed = 11f;
            player.moveSpeed += 0.07f; 
            player.GetModPlayer<ChronosPlayer>().flameThrower = true;
        }
    }
}