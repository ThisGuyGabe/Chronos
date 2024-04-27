using Chronos.Content.Items.References;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chronos.Common.Systems;

public class WorldLoot : ModSystem
{
    public override void PostWorldGen()
    {
        for (int chestIndex = 0; chestIndex < Main.chest.Length; chestIndex++)
        {
            Chest chest = Main.chest[chestIndex];
            int NeedleNum = 1;

            // This is spider chest btw.
            if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 15 * 36)
            {
                if (Main.rand.NextBool(2))
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.WebSlinger)
                        {
                            chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<Needle>());
                            chest.item[inventoryIndex].stack = NeedleNum;
                            break;
                        }
                    }
                }
            }
        }
    }
}
