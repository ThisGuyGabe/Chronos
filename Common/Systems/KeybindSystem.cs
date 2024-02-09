using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;

namespace Chronos.Common.Systems;

public sealed class KeybindSystem : ModSystem {
    public static ModKeybind SuperCritChance { get; private set; }
    public override void Load() {
        SuperCritChance = KeybindLoader.RegisterKeybind(Mod, "SuperCritChance", Keys.None);
    }
    public override void Unload() {
        SuperCritChance = null;
    }
}
