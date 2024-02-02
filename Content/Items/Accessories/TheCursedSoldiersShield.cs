using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chronos.Content.Items.Accessories {
    [AutoloadEquip(EquipType.Shield)]
    public sealed class TheCursedSoldiersShield : ModItem
    {
        public sealed override string Texture => "Chronos/Assets/Textures/Items/Accessories/TheCursedSoldiersShield";
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 10000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.defense = 10;
        }

        public static void ResetEffects(Player player)
        {
            ChronosPlayer p = player.GetModPlayer<ChronosPlayer>();
            p.ichorThrower = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = player.statLifeMax2 * 2 / 3;
            player.buffImmune[BuffID.Ichor] = true;
            player.accRunSpeed = 11f;
            player.moveSpeed += 0.07f;
            player.GetModPlayer<ChronosPlayer>().ichorThrower = true;
        }
    }
}