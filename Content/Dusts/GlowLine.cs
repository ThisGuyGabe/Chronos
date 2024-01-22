﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace Chronos.Content.Dusts;

public sealed class GlowLine : ModDust {
    public sealed override string Texture => "Chronos/Assets/Textures/Dusts/GlowLine";
    public override Color? GetAlpha(Dust dust, Color lightColor) {
		if (dust.fadeIn <= 2)
			return Color.Transparent;

		return dust.color * MathHelper.Min(1, dust.fadeIn / 20f);
	}

	public override void OnSpawn(Dust dust) {
		dust.fadeIn = 0;
		dust.noLight = false;
		dust.frame = new Rectangle(0, 0, 8, 128);
		dust.customData = dust.scale;

		dust.shader = new Terraria.Graphics.Shaders.ArmorShaderData(new Ref<Effect>(ModContent.Request<Effect>("Chronos/Effects/GlowingDust", AssetRequestMode.ImmediateLoad).Value), "GlowingDustPass");
	}

	public override bool Update(Dust dust) {
		if ((float)dust.customData != 0f) {
			//dust.position -= new Vector2(4, 64) * dust.scale;
			dust.scale = (float)dust.customData;
			dust.customData = 0f;
		}

		dust.rotation = dust.velocity.ToRotation() + 1.57f;
		dust.position += dust.velocity;

		dust.velocity *= 0.98f;
		dust.color *= 0.97f;

		if (dust.fadeIn <= 2)
			dust.shader.UseColor(Color.Transparent);
		else
			dust.shader.UseColor(dust.color);

		dust.fadeIn++;

		Lighting.AddLight(dust.position, dust.color.ToVector3() * 0.6f);

		if (dust.fadeIn > 60)
			dust.active = false;
		return false;
	}
}
