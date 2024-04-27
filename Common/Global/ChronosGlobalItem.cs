using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;

namespace Chronos.Common.Global;

public class ChronosGlobalItem : GlobalItem
{
    private static readonly string dayTime = "from 4:30 AM to 7:29 PM";
    private static readonly string nightTime = "from 7:30 PM to 4:29 AM";
    private static readonly string sunsetTime = "from 3:45 PM to 7:30 PM";

    private static readonly Dictionary<int, string> TooltipTexts = new()
    {
        { ItemID.DaybloomSeeds, $"[i:313] grows during the day, {dayTime}." },
        { ItemID.MoonglowSeeds, $"[i:314] grows during the night, {nightTime}." },
        { ItemID.BlinkrootSeeds, $"[i:315] grows at random." },
        { ItemID.DeathweedSeeds, $"[i:316] grows during a blood moon, full moon, or at night, {nightTime}." },
        { ItemID.WaterleafSeeds, $"[i:317] grows during the rain." },
        { ItemID.FireblossomSeeds, $"[i:318] grows during sunset, {sunsetTime}, unless it's raining." },
        { ItemID.ShiverthornSeeds, $"[i:2358] wait for enough time to pass, and it will fully blossom." }
    };

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        if (TooltipTexts.TryGetValue(item.type, out var text))
        {
            tooltips.Add(new TooltipLine(Mod, $"thing{item.type}", text));
        }
    }
}
