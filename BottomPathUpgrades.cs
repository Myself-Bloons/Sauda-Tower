using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.Collections.Generic;

namespace SaudaMod.Upgrades
{
    public class FasterSlices : ModUpgrade<SaudaTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 400;
        public override string Description => "Attacks faster.";
        public override string DisplayName => "Faster Slices";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                attack.weapons[0].rate *= 0.75f;
            }
        }
    }

    public class EvenFasterSlices : ModUpgrade<SaudaTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 600;
        public override string Description => "Attacks even faster.";
        public override string DisplayName => "Even Faster Slices";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                attack.weapons[0].rate *= 0.7f;
            }
        }
    }

    public class DebandingSlices : ModUpgrade<SaudaTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 3400;
        public override string Description => "Attacks remove fortification.";
        public override string DisplayName => "De-banding Slices";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                var projectile = attack.weapons[0].projectile;

                var removeModifiers = new RemoveBloonModifiersModel(
                    "RemoveFortified",
                    false,
                    false,
                    false,
                    true,
                    false,
                    new Il2CppStringArray(new string[] { "Bfb", "Zomb", "Ddt", "Bad" }),
                    new Il2CppStringArray(new string[] { })
                );
                projectile.AddBehavior(removeModifiers);

                var damageModel = projectile.GetDamageModel();
                if (damageModel != null)
                {
                    damageModel.damage = 5;
                }
                attack.weapons[0].rate = 0.4f;
            }
        }
    }

    public class LightningFastSlices : ModUpgrade<SaudaTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 4600;
        public override string Description => "Attacks at the speed of lightning.";
        public override string DisplayName => "Lightning-Fast Slices";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                attack.weapons[0].rate = 0.2f;
                var projectile = attack.weapons[0].projectile;
                var damageModel = projectile.GetDamageModel();
                if (damageModel != null)
                {
                    damageModel.damage = 10;
                }
            }
        }
    }

    public class SoudaSwordMaster : ModUpgrade<SaudaTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 38000;
        public override string Description => "The master of swords.";
        public override string DisplayName => "Sauda Sword Master";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                attack.weapons[0].rate = 0.05f;

                var projectile = attack.weapons[0].projectile;
                var damageModel = projectile.GetDamageModel();
                if (damageModel != null)
                {
                    damageModel.damage = 15;
                    damageModel.immuneBloonProperties = BloonProperties.None;
                }
            }
        }
    }
}
