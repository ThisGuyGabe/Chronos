using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Chronos.Core;

public static class BaseTypeCommons {
	public static string GetKeyPath(Type type) {
		// Ignore Chronos and Content folders
		return string.Join('.', type.Namespace.Split('.')[2..]);
	}
}

public abstract class BaseItem : ModItem {
	private string KeyPath => BaseTypeCommons.GetKeyPath(GetType());
	public override LocalizedText DisplayName => Language.GetOrRegister($"Mods.Chronos.{KeyPath}.{Name}.DisplayName", PrettyPrintName);
	public override LocalizedText Tooltip => Language.GetOrRegister($"Mods.Chronos.{KeyPath}.{Name}.Tooltip", () => string.Empty);
}
public abstract class BaseNPC : ModNPC {
	private string KeyPath => BaseTypeCommons.GetKeyPath(GetType());
	public override LocalizedText DisplayName => Language.GetOrRegister($"Mods.Chronos.{KeyPath}.{Name}.DisplayName", PrettyPrintName);
}