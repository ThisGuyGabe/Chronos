using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Chronos.Content.UI;
using Chronos.Content.DamageClasses;
using Chronos.Content.Items.Ingredients;
using Chronos.Content.Buffs;

namespace Chronos.Content.Items.Chef;

public class FryingPan : ModItem
{
    public override string Texture => "Chronos/Assets/Items/Chef/FryingPan";

    public Item panitem1 = new Item();
    public Item panitem2 = new Item();
    public Item panitem3 = new Item();
    public bool gui_open = false;
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }
    public override void SetDefaults()
    {
        Item.damage = 3;
        Item.width = 40;
        Item.height = 40;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.DamageType = ModContent.GetInstance<ChefClass>();
        Item.useStyle = ItemUseStyleID.HiddenAnimation;
        Item.knockBack = 2;
        Item.value = 10000;
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<FryingPanProjectile>();
        Item.shootSpeed = 15f;
        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
    }
    public override bool AltFunctionUse(Player player)
    {
        return true;
    }
    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        damage = Item.damage + panitem1.damage + panitem2.damage + panitem3.damage;
        if (player.altFunctionUse == 2)
        {
            type = ProjectileID.None;
        }
        else
        {
            type = ModContent.ProjectileType<FryingPanProjectile>();
        }
    }
    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            Item.UseSound = null;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
        }
        else
        {
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;
        }
        return !Main.projectile.Any(n => n.active && n.owner == player.whoAmI && n.type == ModContent.ProjectileType<FryingPanProjectile>());
    }
    public override bool? UseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            if (ModContent.GetInstance<guisystem>()._State.CurrentState == ModContent.GetInstance<guisystem>().panGUIState && gui_open == true)
            {
                ModContent.GetInstance<guisystem>()._State.SetState(null);
                panitem1 = ModContent.GetInstance<guisystem>().panGUIState.mainIngredient.Item;
                panitem2 = ModContent.GetInstance<guisystem>().panGUIState.flavorIngredient.Item;
                panitem3 = ModContent.GetInstance<guisystem>().panGUIState.sideIngredient.Item;
                gui_open = false;
            }
            else
            {
                if (ModContent.GetInstance<guisystem>()._State.CurrentState != ModContent.GetInstance<guisystem>().panGUIState)
                {
                    ModContent.GetInstance<guisystem>()._State.SetState(ModContent.GetInstance<guisystem>().panGUIState);
                    ModContent.GetInstance<guisystem>().panGUIState.mainIngredient.Item = panitem1;
                    ModContent.GetInstance<guisystem>().panGUIState.flavorIngredient.Item = panitem2;
                    ModContent.GetInstance<guisystem>().panGUIState.sideIngredient.Item = panitem3;
                    gui_open = true;
                }
            }
        }
        return true;
    }
    public override void SaveData(TagCompound tag)
    {
        tag["PanItem1"] = panitem1;
        tag["PanItem2"] = panitem2;
        tag["PanItem3"] = panitem3;
    }
    public override void LoadData(TagCompound tag)
    {
        if (tag.TryGet<Item>("PanItem1", out Item item1))
        {
            panitem1 = item1;
        }
        if (tag.TryGet<Item>("PanItem2", out Item item2))
        {
            panitem2 = item2;
        }
        if (tag.TryGet<Item>("PanItem3", out Item item3))
        {
            panitem3 = item3;
        }

    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 12)
            .AddTile(TileID.Anvils)
            .Register();
    }
}

public class FryingPanProjectile : ModProjectile
{
    public override string Texture => "Chronos/Assets/Items/Chef/FryingPan";

    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
    }
    public override void SetDefaults()
    {
        Projectile.width = 32;
        Projectile.height = 32;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 40;
        Projectile.alpha = 0;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.extraUpdates = 1;
        Projectile.CountsAsClass<ChefClass>();
    }
    Vector2 mouseForAI = new Vector2();
    float mouseDistance = 0f;
    public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
    {
        Player player = Main.player[Projectile.owner];
        if (player.HeldItem.ModItem is FryingPan pan)
        {
            if (pan.panitem2.type == ModContent.ItemType<Sugar>())
            {
                target.AddBuff(ModContent.BuffType<Cavities>(), Main.rand.Next(440, 640));
            }
        }

    }
    public override void AI()
    {

        Player player = Main.player[Projectile.owner];
        Projectile.ai[0]++;
        if (player.HeldItem.ModItem is FryingPan pan)
        {
            if (pan.panitem1.IsAir)
            {
                Projectile.rotation = Projectile.rotation + (Projectile.ai[0] / 50f);
                if (Projectile.ai[0] >= 20)
                {
                    Projectile.velocity = (Projectile.velocity + (Projectile.Center.DirectionTo(player.Center) * 15) + Projectile.rotation.ToRotationVector2() * 2) / 2;
                }
                if (Projectile.ai[0] >= 5)
                {
                    if (Projectile.Center.Distance(player.Center) <= 5)
                    {
                        Projectile.timeLeft = 0;
                    }
                }
            }
            if (pan.panitem1.type == ModContent.ItemType<Egg>())
            {
                if (Projectile.ai[0] == 1)
                {
                    mouseForAI = Main.MouseWorld;
                    mouseDistance = Projectile.Center.Distance(mouseForAI);
                    Projectile.velocity = Projectile.Center.DirectionTo(mouseForAI) * mouseDistance / 40;
                    Projectile.velocity *= 2f;
                }
                Projectile.velocity *= 0.96f;
                Projectile.rotation = Projectile.velocity.ToRotation() + 0.785398f;
                if (Projectile.ai[0] % 10 == 5)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(Main.rand.Next(-3, 3), Main.rand.Next(-9, -6)), ModContent.ProjectileType<FriedEgg>(), Projectile.damage, 1);
                }
            }
        }
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Player player = Main.player[Projectile.owner];
        if (player.HeldItem.ModItem is FryingPan pan && pan.panitem1.IsAir)
        {
            Projectile.ai[0] = 5;
            Projectile.velocity *= -1;
            if (Projectile.Center.Distance(player.Center) <= 5)
            {
                Projectile.timeLeft = 0;
            }
            return false;

        }
        return false;
    }
}