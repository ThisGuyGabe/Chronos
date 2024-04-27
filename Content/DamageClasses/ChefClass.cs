using Terraria.ModLoader;

namespace Chronos.Content.DamageClasses;

public class ChefClass : DamageClass
{

}
public class ChefMainClass : DamageClass
{
    public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
    {
        if (damageClass == ModContent.GetInstance<ChefClass>())
        {
            return new StatInheritanceData(
                damageInheritance: 1f,
                critChanceInheritance: -1f,
                attackSpeedInheritance: 0.4f,
                armorPenInheritance: 2.5f,
                knockbackInheritance: 0f
            );
        }
        return new StatInheritanceData(
            damageInheritance: 0f,
            critChanceInheritance: 0f,
            attackSpeedInheritance: 0f,
            armorPenInheritance: 0f,
            knockbackInheritance: 0f
        );
    }
    public override bool GetEffectInheritance(DamageClass damageClass)
    {
        if (damageClass == ModContent.GetInstance<ChefClass>())
            return true;
        return false;
    }
}

public class ChefFlavorClass : DamageClass
{
    public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
    {
        if (damageClass == ModContent.GetInstance<ChefClass>())
        {
            return new StatInheritanceData(
                damageInheritance: 1f,
                critChanceInheritance: -1f,
                attackSpeedInheritance: 0.4f,
                armorPenInheritance: 2.5f,
                knockbackInheritance: 0f
            );
        }
        return new StatInheritanceData(
            damageInheritance: 0f,
            critChanceInheritance: 0f,
            attackSpeedInheritance: 0f,
            armorPenInheritance: 0f,
            knockbackInheritance: 0f
        );
    }
    public override bool GetEffectInheritance(DamageClass damageClass)
    {
        if (damageClass == ModContent.GetInstance<ChefClass>())
            return true;
        return false;
    }
}
public class ChefSideClass : DamageClass
{
    public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
    {
        if (damageClass == ModContent.GetInstance<ChefClass>())
        {
            return new StatInheritanceData(
                damageInheritance: 1f,
                critChanceInheritance: -1f,
                attackSpeedInheritance: 0.4f,
                armorPenInheritance: 2.5f,
                knockbackInheritance: 0f
            );
        }
        return new StatInheritanceData(
            damageInheritance: 0f,
            critChanceInheritance: 0f,
            attackSpeedInheritance: 0f,
            armorPenInheritance: 0f,
            knockbackInheritance: 0f
        );
    }
    public override bool GetEffectInheritance(DamageClass damageClass)
    {
        if (damageClass == ModContent.GetInstance<ChefClass>())
            return true;
        return false;
    }
}