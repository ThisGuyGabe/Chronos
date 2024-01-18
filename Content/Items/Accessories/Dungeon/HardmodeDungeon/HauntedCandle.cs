using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemporaryModName.Content.Items.Accessories.Dungeon.HardmodeDungeon;

public sealed class HauntedCandle : ModItem {
    public sealed override string Texture => "TemporaryModName/Assets/Textures/Items/Accessories/Dungeon/HardmodeDungeon/HauntedCandle";
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
		Item.value = Item.sellPrice(gold: 6, silver: 50); // Similiar to something like the Paladin's Shield.
	}

    public override void UpdateAccessory(Player player, bool hideVisual) { 
        if (player.statLife <= player.statLifeMax2 / 2) // When u are half health.
        {
            player.GetDamage(DamageClass.Generic) += 0.18f; // 18% damage boost, 12% crit boost, and 6% attack speed boost.
            player.GetCritChance(DamageClass.Generic) += 0.12f;
            player.GetAttackSpeed(DamageClass.Generic) += 0.06f;

            player.statDefense -= 8; // -8 defense and -2% damage reduction
            player.endurance -= 0.02f;

            player.statManaMax2 += 40;
        }
        else
        {
            player.GetDamage(DamageClass.Generic) -= 0.10f; // -10% damage, -8% crit chance, and -6% attack speed.
            player.GetCritChance(DamageClass.Generic) -= 0.08f;
            player.GetAttackSpeed(DamageClass.Generic) -= -0.06f;

            player.statDefense += 25; // +25 defense and 6% damage reduction.
            player.endurance += 0.06f;

            player.statManaMax2 += 80;
        }
        // Basically higher the health lower your offensive stats are but your defensive stats are boosted such as defense and endurance. The lower your health offensive stats are higher and defense and endurance is lower.
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
