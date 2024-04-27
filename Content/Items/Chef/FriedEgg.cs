using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Chronos.Content.DamageClasses;

namespace Chronos.Content.Items.Chef;

public class FriedEgg : ModProjectile
{
    public override string Texture => "Chronos/Assets/Items/Chef/FriedEgg";

    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
    }
    public override void SetDefaults()
    {
        Projectile.width = 26;
        Projectile.height = 20;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 120;
        Projectile.alpha = 0;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.extraUpdates = 1;
        Projectile.CountsAsClass<ChefClass>();
    }
    public override void AI()
    {
        Projectile.velocity.Y += 0.16333333333f;
        Projectile.velocity.X *= 0.95f;
        Projectile.rotation = Projectile.velocity.ToRotation() + 0.785398f;
        Projectile.ai[0]++;
        if (Projectile.ai[0] == 60)
        {
            for (int i = 0; i < 45; i++)
            {
                double deg = i * 8;
                double rad = (deg) * (Math.PI / 180);
                double dist = 10;

                float x2 = Projectile.Center.X - (int)(Math.Cos(rad) * dist);
                float y2 = Projectile.Center.Y - (int)(Math.Sin(rad) * dist);
                int dust = Dust.NewDust(new Vector2(x2, y2), 1, 1, DustID.WhiteTorch, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust].noGravity = true;
            }
            Projectile.velocity = (Projectile.velocity + Projectile.velocity + new Vector2(0, 20)) / 2;
        }

    }
}