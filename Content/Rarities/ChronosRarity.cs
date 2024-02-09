using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Chronos.Content.Rarities;

public sealed class ChronosRarity : ModRarity {
    public override Color RarityColor => new(255, 45, 45);
    public override int GetPrefixedRarity(int offset, float valueMult) {
        return Type;
    }
}
