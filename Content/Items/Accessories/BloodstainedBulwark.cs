using Terraria;
using Terraria.ModLoader;
using Chronos.Content.Buffs;
using Chronos.Common.Systems;
using Chronos.Common;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using Chronos.Content.Rarities;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.UI.Chat;
using Terraria.Audio;
using Chronos.Core;
using ReLogic.Content;

namespace Chronos.Content.Items.Accessories;

[AutoloadEquip(EquipType.Shield)]
public class BloodstainedBulwark : BaseItem 
{
    public override string Texture => "Chronos/Assets/Textures/Items/Accessories/BloodstainedBulwark";

    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 32;
        Item.value = Item.sellPrice(gold: 2);
        Item.rare = ModContent.RarityType<ChronosRarity>();
        Item.accessory = true;
        Item.defense = 2;
    }

    public override void UpdateAccessory(Player player, bool hideVisual) {
        if (!player.HasBuff(ModContent.BuffType<Rampage>()) && KeybindSystem.SuperCritChance.JustPressed) {
            if (!player.HasBuff(ModContent.BuffType<Cooldown>())) {
                player.AddBuff(ModContent.BuffType<Rampage>(), 300);
                player.AddBuff(ModContent.BuffType<Cooldown>(), 1800);

                SoundEngine.PlaySound(ChronosSounds.ShieldReady, player.Center);
            }
            else {
                CombatText.NewText(player.getRect(), Color.Red, "Cooldown active!", true);
            }
        }
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips) {
        foreach (string key in KeybindSystem.SuperCritChance.GetAssignedKeys()) {
            foreach (TooltipLine line in tooltips) {
                if (line.Mod == "Terraria" && line.Name == "Tooltip0") {
                    line.Text = Language.GetTextValue("Mods.Chronos.CommonItemTooltip.BrainOfCthulhuShieldText", key);
                }
            }
        }
    }

    Effect Bloodstain;
    static void SetEffectParameters(Effect effect) {
        effect.Parameters["uTime"].SetValue((float)(Main.timeForVisualEffects * 0.045f));
    }

    static bool ShaderTooltip(DrawableTooltipLine line, Effect shader) {
        Vector2 textPos = new(line.X, line.Y);
        for (float i = 0; i < 1; i += 0.25f) {
            Vector2 borderOffset = (i * MathF.Tau).ToRotationVector2() * 2;
            ChatManager.DrawColorCodedString(Main.spriteBatch, line.Font, line.Text, textPos + borderOffset, Color.Black, line.Rotation, line.Origin, line.BaseScale);
        }
        SetEffectParameters(shader);
        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, shader, Main.UIScaleMatrix);
        ChatManager.DrawColorCodedString(Main.spriteBatch, line.Font, line.Text, textPos, Color.Red, line.Rotation, line.Origin, line.BaseScale);
        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);
        return false;
    }

    public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset) {
        Bloodstain ??= ModContent.Request<Effect>("Chronos/Effects/BloodstainEffect", AssetRequestMode.ImmediateLoad).Value;
        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);
        if (line.Index == 0)
            return ShaderTooltip(line, Bloodstain);
        return true;
    }
}
/* TODO:
 * Now we only need to do the parry that makes it so 
 * it can block projectiles and contact damage make the player slugglish or something because 
*/