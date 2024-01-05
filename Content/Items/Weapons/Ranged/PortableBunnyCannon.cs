using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemporaryModName.Content.Items.Weapons.Ranged
{
    public class PortableBunnyCannon : ModItem
    {
        public override string Texture => "TemporaryModName/Assets/Weapons/Ranged/PortableBunnyCannon";
        public override void SetDefaults()
        {
            Item.width = 54;
            Item.height = 40;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.UseSound = SoundID.Item14;
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(gold: 50);
            Item.value = Item.sellPrice(gold: 10);
            Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.useAmmo = ItemID.ExplosiveBunny;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileID.ExplosiveBunny;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BunnyCannon)
                .Register();
        }
    }
}
