using Terraria;
using Terraria.ModLoader;
using Chronos.Content.Buffs;
using Chronos.Common.Systems;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using Chronos.Content.Rarities;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.UI.Chat;

namespace Chronos.Content.Items.Accessories;

[AutoloadEquip(EquipType.Shield)]
public sealed class BloodstainedBulwark : ModItem {
    public sealed override string Texture => "Chronos/Assets/Textures/Items/Accessories/BloodstainedBulwark";

    int timer;
    public bool readyToShowText;

    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 32;
        Item.value = Item.sellPrice(gold: 2);
        Item.rare = ModContent.RarityType<ChronosRarity>();
        Item.accessory = true;
        Item.defense = 2;
    }
    public override void UpdateAccessory(Player player, bool hideVisual) {
        if (!player.HasBuff(ModContent.BuffType<Rampage>())) {
            timer++;
            if (timer >= 600) {
                if (KeybindSystem.SuperCritChance.JustPressed) {
                    player.AddBuff(ModContent.BuffType<Rampage>(), 300);
                    timer = 0;
                    readyToShowText = true;
                    CombatText.NewText(player.getRect(), Color.Blue, "Ready", true);
                }
            }
        }
    }
    public override void ModifyTooltips(List<TooltipLine> tooltips) {
        foreach (string key in KeybindSystem.SuperCritChance.GetAssignedKeys()) {
            foreach (TooltipLine line in tooltips) {
                if (line.Mod == "Terraria" && line.Name == "Tooltip0") {
                    line.Text = Language.GetTextValue("Mods.Chronos.Chronos.ModifiedTooltips.BrainOfCthulhuShieldText", key);
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
        Bloodstain ??= ModContent.Request<Effect>("Chronos/Effects/BloodstainEffect", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);
        if (line.Index == 0)
            return ShaderTooltip(line, Bloodstain);
        return true;
    }
}
