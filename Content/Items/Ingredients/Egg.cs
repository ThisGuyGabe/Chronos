using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Chronos.Content.DamageClasses;

namespace Chronos.Content.Items.Ingredients;

public class Egg : ModItem
{
    public override string Texture => "Chronos/Assets/Items/Ingredients/Egg";
    public override void SetDefaults()
    {
        Item.damage = 3;
        Item.DamageType = ModContent.GetInstance<ChefMainClass>();
        Item.width = 40;
        Item.height = 40;
        Item.value = 14320;
        Item.rare = ItemRarityID.Green;
        Item.maxStack = 1;
    }
}