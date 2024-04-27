using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Chronos.Content.DamageClasses;

namespace Chronos.Content.Items.Ingredients;

public class Sugar : ModItem
{
    public override string Texture => "Chronos/Assets/Items/Ingredients/Sugar";

    public override void SetDefaults()
    {
        Item.damage = 1;
        Item.DamageType = ModContent.GetInstance<ChefFlavorClass>();
        Item.width = 40;
        Item.height = 40;
        Item.value = 14320;
        Item.rare = ItemRarityID.Green;
        Item.maxStack = 1;
    }
}