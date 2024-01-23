﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Chronos.Content.Items.Armor.Vanity.AquaticDiverSet
{
	[AutoloadEquip(EquipType.Head)]
	public class AquaticDiverHelmet : ModItem
	{
        public sealed override string Texture => "Chronos/Assets/Textures/Items/Armor/Vanity/AquaticDiverSet/AquaticDiverHelmet";
        public override void SetDefaults() 
		{
			Item.width = 32;
			Item.height = 34;
			Item.value = Item.sellPrice(silver: 75);
			Item.rare = ItemRarityID.Green;
			Item.vanity = true;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 20)
                .AddIngredient(ItemID.Coral, 3)
                .AddIngredient(ItemID.Seashell, 1)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}