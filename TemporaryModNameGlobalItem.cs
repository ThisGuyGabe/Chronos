using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemporaryModName 
{
	public class GenericGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if(item.type == ItemID.Cannonball)
			{
				item.ammo = ItemID.Cannonball;
				item.shoot = ProjectileID.CannonballFriendly;
			}

			if(item.type == ItemID.ExplosiveBunny)
			{
				item.ammo = ItemID.ExplosiveBunny;
				item.shoot = ProjectileID.ExplosiveBunny;
			}
		}
	}
}
