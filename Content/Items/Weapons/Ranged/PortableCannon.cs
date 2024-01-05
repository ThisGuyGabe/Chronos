using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemporaryModName.Content.Items.Weapons.Ranged
{
	public class PortableCannon : ModItem
	{
        public override string Texture => "TemporaryModName/Assets/Weapons/Ranged/PortableCannon";
        public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 34;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
            Item.UseSound = SoundID.Item14;
            Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(gold: 25);
			Item.value = Item.sellPrice(gold: 5);
			Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;
            Item.useAmmo = ItemID.Cannonball;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileID.CannonballFriendly;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Cannon)
                .Register();
        }
	}
}
