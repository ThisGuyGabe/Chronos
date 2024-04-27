using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameInput;
using Chronos.Content.DamageClasses;

namespace Chronos.Content.UI;

public class MainIngredient : UIElement
{
    internal Item Item;
    private readonly int _context;
    private readonly float _scale;
    internal Func<Item, bool> ValidItemFunc;

    public MainIngredient(int context = ItemSlot.Context.BankItem, float scale = 1f)
    {
        _context = context;
        _scale = scale;
        Item = new Item();
        Item.SetDefaults(0);

        Width.Set(TextureAssets.InventoryBack9.Value.Width * scale, 0f);
        Height.Set(TextureAssets.InventoryBack9.Value.Height * scale, 0f);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        float oldScale = Main.inventoryScale;
        Main.inventoryScale = _scale;
        Rectangle rectangle = GetDimensions().ToRectangle();

        if (ContainsPoint(Main.MouseScreen) && !PlayerInput.IgnoreMouseInterface)
        {
            Main.LocalPlayer.mouseInterface = true;
            if (ValidItemFunc == null || ValidItemFunc(Main.mouseItem))
            {
                if (Main.mouseItem.CountsAsClass<ChefMainClass>() || Main.mouseItem.IsAir)
                {

                    ItemSlot.Handle(ref Item, _context);
                }

            }
        }
        ItemSlot.Draw(spriteBatch, ref Item, _context, rectangle.TopLeft());
        Main.inventoryScale = oldScale;
    }
}
internal class FlavorIngredient : UIElement
{
    internal Item Item;
    private readonly int _context;
    private readonly float _scale;
    internal Func<Item, bool> ValidItemFunc;

    public FlavorIngredient(int context = ItemSlot.Context.BankItem, float scale = 1f)
    {
        _context = context;
        _scale = scale;
        Item = new Item();
        Item.SetDefaults(0);

        Width.Set(TextureAssets.InventoryBack9.Value.Width * scale, 0f);
        Height.Set(TextureAssets.InventoryBack9.Value.Height * scale, 0f);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        float oldScale = Main.inventoryScale;
        Main.inventoryScale = _scale;
        Rectangle rectangle = GetDimensions().ToRectangle();

        if (ContainsPoint(Main.MouseScreen) && !PlayerInput.IgnoreMouseInterface)
        {
            Main.LocalPlayer.mouseInterface = true;
            if (ValidItemFunc == null || ValidItemFunc(Main.mouseItem))
            {
                if (Main.mouseItem.CountsAsClass<ChefFlavorClass>() || Main.mouseItem.IsAir)
                {

                    ItemSlot.Handle(ref Item, _context);
                }

            }
        }
        ItemSlot.Draw(spriteBatch, ref Item, _context, rectangle.TopLeft());
        Main.inventoryScale = oldScale;
    }
}
internal class SideIngredient : UIElement
{
    internal Item Item;
    private readonly int _context;
    private readonly float _scale;
    internal Func<Item, bool> ValidItemFunc;

    public SideIngredient(int context = ItemSlot.Context.BankItem, float scale = 1f)
    {
        _context = context;
        _scale = scale;
        Item = new Item();
        Item.SetDefaults(0);

        Width.Set(TextureAssets.InventoryBack9.Value.Width * scale, 0f);
        Height.Set(TextureAssets.InventoryBack9.Value.Height * scale, 0f);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        float oldScale = Main.inventoryScale;
        Main.inventoryScale = _scale;
        Rectangle rectangle = GetDimensions().ToRectangle();

        if (ContainsPoint(Main.MouseScreen) && !PlayerInput.IgnoreMouseInterface)
        {
            Main.LocalPlayer.mouseInterface = true;
            if (ValidItemFunc == null || ValidItemFunc(Main.mouseItem))
            {
                if (Main.mouseItem.CountsAsClass<ChefSideClass>() || Main.mouseItem.IsAir)
                {

                    ItemSlot.Handle(ref Item, _context);
                }

            }
        }
        ItemSlot.Draw(spriteBatch, ref Item, _context, rectangle.TopLeft());
        Main.inventoryScale = oldScale;
    }
}
class panGUIState : UIState
{
    public MainIngredient mainIngredient;
    public FlavorIngredient flavorIngredient;
    public SideIngredient sideIngredient;
    public override void OnInitialize()
    {
        mainIngredient = new MainIngredient();
        mainIngredient.Left.Set(-TextureAssets.InventoryBack9.Value.Width / 2 - TextureAssets.InventoryBack9.Value.Width, 0.5f);
        mainIngredient.Top.Set(-TextureAssets.InventoryBack9.Value.Height / 2 - TextureAssets.InventoryBack9.Value.Height, 0.5f);

        flavorIngredient = new FlavorIngredient();
        flavorIngredient.Left.Set(-TextureAssets.InventoryBack9.Value.Width / 2, 0.5f);
        flavorIngredient.Top.Set(-TextureAssets.InventoryBack9.Value.Height / 2 - TextureAssets.InventoryBack9.Value.Height, 0.5f);

        sideIngredient = new SideIngredient();
        sideIngredient.Left.Set(-TextureAssets.InventoryBack9.Value.Width / 2 + TextureAssets.InventoryBack9.Value.Width, 0.5f);
        sideIngredient.Top.Set(-TextureAssets.InventoryBack9.Value.Height / 2 - TextureAssets.InventoryBack9.Value.Height, 0.5f);

        Append(mainIngredient);
        Append(flavorIngredient);
        Append(sideIngredient);
    }
}
class guisystem : ModSystem
{
    internal panGUIState panGUIState;
    public UserInterface _State;
    public override void Load()
    {
        panGUIState = new panGUIState();
        panGUIState.Activate();
        _State = new UserInterface();
        _State.SetState(null);
    }
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if (mouseTextIndex != -1)
        {
            layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                "CascadeMod: A Description",
                delegate
                {
                    _State.Draw(Main.spriteBatch, new GameTime());
                    return true;
                },
                InterfaceScaleType.UI)
            );
        }
    }
}