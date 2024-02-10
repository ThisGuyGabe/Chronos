using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chronos.Content.Items.Accessories.Dungeon.HardmodeDungeon;

public sealed class HauntedCandle : ModItem {
    public sealed override string Texture => "Chronos/Assets/Textures/Items/Accessories/Dungeon/HardmodeDungeon/HauntedCandle";
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
        // the variation between the a player's current amount of life and the maximum amount of life
        int lifeDifference = player.statLifeMax2 - player.statLife;

        // the defensive and damage multipliers according to the difference in life
        float damageMultiplier = lifeDifference > 0 ? 0.01f * lifeDifference : 1;
        float defenseMultiplier = lifeDifference > 0 ? 10f / lifeDifference : 1;

        // Updates the player's stats according to the determined multipliers.
        player.statDefense *= defenseMultiplier;
        player.GetDamage(DamageClass.Generic) *= damageMultiplier;
    }

    public override void AddRecipes() {
		CreateRecipe()
			.AddIngredient(ItemID.WaterCandle, 1)
			.AddIngredient(ItemID.Ectoplasm, 5)
			.AddIngredient(ItemID.Bone, 25)
            .AddTile(TileID.TinkerersWorkbench)
            .Register(); // Not the final recipe as I will be working on stranza's concept.
    }
}
