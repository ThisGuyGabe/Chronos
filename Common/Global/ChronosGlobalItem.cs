using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace Chronos.Common.Global
{
    public class ChronosGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.DaybloomSeeds:
                    tooltips.Add(new(Mod, "thing1", $"[i:313] grows during the day, from 4:30 AM to 7:29 PM."));
                    break;
                case ItemID.MoonglowSeeds:
                    tooltips.Add(new(Mod, "thing2", $"[i:314] grows during the night from 7:30 PM to 4:29 AM."));
                    break;
                case ItemID.BlinkrootSeeds:
                    tooltips.Add(new(Mod, "thing3", $"[i:315] grows at random."));
                    break;
                case ItemID.DeathweedSeeds:
                    tooltips.Add(new(Mod, "thing4", $"[i:316] grows during a blood moon, full moon, or at night from 7:30 PM to 4:29 AM."));
                    break;
                case ItemID.WaterleafSeeds:
                    tooltips.Add(new(Mod, "thing5", $"[i:317] grows during the rain."));
                    break;
                case ItemID.FireblossomSeeds:
                    tooltips.Add(new(Mod, "thing6", $"[i:318] grows during sunset from 3:45 PM to 7:30 PM, unless it's raining."));
                    break;
                case ItemID.ShiverthornSeeds:
                    tooltips.Add(new(Mod, "thing7", $"[i:2358] wait for enough time to pass, and it will fully blossom."));
                    break;
            }
        }
    }
}
