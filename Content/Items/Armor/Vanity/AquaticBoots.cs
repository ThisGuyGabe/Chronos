using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Chronos.Core;

namespace Chronos.Content.Items.Armor.Vanity.AquaticDiverSet;

[AutoloadEquip(EquipType.Legs)]
public class AquaticBoots : BaseItem 
{
    public override string Texture => "Chronos/Assets/Textures/Items/Armor/Vanity/AquaticBoots";

    public override void SetDefaults() {
        Item.width = 22;
        Item.height = 18;
        Item.value = Item.sellPrice(silver: 45);
        Item.rare = ItemRarityID.Green;
        Item.vanity = true;
    }

    public override void AddRecipes() {
        CreateRecipe()
            .AddIngredient(ItemID.Silk, 20)
            .AddIngredient(ItemID.Coral, 3)
            .AddIngredient(ItemID.Seashell, 1)
            .AddTile(TileID.Loom)
            .Register();
    }
}
