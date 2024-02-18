using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Chronos.Core;

namespace Chronos.Content.Items;

public class DayAndNightSwitch : BaseItem 
{
    public override string Texture => "Chronos/Assets/Textures/Missing";

    public sealed override void SetDefaults() {
        Item.width = 32;
        Item.height = 32;
        Item.rare = ItemRarityID.Pink; // I'll make a basic rarity that lerps between yellow and blue colors.
        Item.value = Item.sellPrice(gold: 6);

        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useAnimation = 30;
        Item.useTime = 30;
        Item.UseSound = SoundID.Item4;
    }

    public sealed override bool? UseItem(Player player) {
        if (player.itemTime == 0 && player.itemAnimation > 0) {
            player.itemTime = Item.useTime;

            bool conditionToChange = !Main.dayTime;
            int dustType = 68 ^ (352 * (conditionToChange ? 1 : 0));

            for (int i = 0; i < 50; i++) {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                Dust.NewDustPerfect(player.Top, dustType, speed * 5, Scale: 1.5f).noGravity = true;
            }

            Main.time = 0.0;
            Main.dayTime = !Main.dayTime;
            if (Main.netMode == NetmodeID.MultiplayerClient) {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
        return false;
    }
}
