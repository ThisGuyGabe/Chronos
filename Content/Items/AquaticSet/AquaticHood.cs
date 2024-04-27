using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Chronos.Content.Items.AquaticSet;

[AutoloadEquip(EquipType.Head)]
public class AquaticHood : ModItem
{
    public override string Texture => "Chronos/Assets/Items/AquaticSet/AquaticHood";

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
