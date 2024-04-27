using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chronos.Content.Items.AquaticSet;

[AutoloadEquip(EquipType.Body)]
public class AquaticPlating : ModItem
{
    public override string Texture => "Chronos/Assets/Items/AquaticSet/AquaticPlating";

    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 20;
        Item.value = Item.sellPrice(silver: 60);
        Item.rare = ItemRarityID.Green;
        Item.vanity = true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Silk, 20)
            .AddIngredient(ItemID.Coral, 5)
            .AddIngredient(ItemID.Seashell, 1)
            .AddTile(TileID.Loom)
            .Register();
    }
}
