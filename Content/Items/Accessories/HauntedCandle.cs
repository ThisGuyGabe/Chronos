using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Chronos.Core;

namespace Chronos.Content.Items.Accessories;

public class HauntedCandle : BaseItem 
{
    public override string Texture => "Chronos/Assets/Textures/Items/Accessories/HauntedCandle";

    public override void SetStaticDefaults() {
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		ItemID.Sets.ItemIconPulse[Item.type] = false;
		ItemID.Sets.ItemNoGravity[Item.type] = false;
	}

	public override void SetDefaults() {
		Item.width = 40;
		Item.height = 42;
		Item.rare = ItemRarityID.Yellow; // It's yellow rarity because yellow rarity stuff is made with ectoplasm.
		Item.accessory = true;
		Item.value = Item.sellPrice(gold: 6, silver: 50); // Similar to something like the Paladin's Shield.
	}

    public override void UpdateAccessory(Player player, bool hideVisual) {
        int LifeDifference = player.statLifeMax2 - player.statLife;

        float DamageMultiplier = LifeDifference > 0 ? 0.01f * LifeDifference : 1;
        float DefenseMultiplier = LifeDifference > 0 ? 10f / LifeDifference : 1;

        player.statDefense *= DefenseMultiplier;
        player.GetDamage(DamageClass.Generic) *= DamageMultiplier;
    }

    public override void AddRecipes() {
		CreateRecipe()
			.AddIngredient(ItemID.WaterCandle, 1)
			.AddIngredient(ItemID.Ectoplasm, 5)
			.AddIngredient(ItemID.Bone, 25)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}
