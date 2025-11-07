using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Unity;
using System.Linq;

namespace SaudaMod.Upgrades
{
    public class SharpEyesight : ModUpgrade<SaudaTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 650;
        public override string Description => "Increases sauda's range.";
        public override string DisplayName => "Sharp Eyesight";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null)
            {
                attack.range *= 2f;
            }
            towerModel.range *= 2f;
            towerModel.radius *= 2f;
        }
    }

    public class SharpSwords : ModUpgrade<SaudaTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 600;
        public override string Description => "Increases pierce of sauda's swords.";
        public override string DisplayName => "Sharp Swords";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                var projectile = attack.weapons[0].projectile;
                projectile.pierce *= 2;
            }
        }
    }

    public class LongSwords : ModUpgrade<SaudaTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 1500;
        public override string Description => "Increases sauda's range and pierce.";
        public override string DisplayName => "Long Swords";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null)
            {
                attack.range *= 1.5f;
                if (attack.weapons.Length > 0)
                {
                    var projectile = attack.weapons[0].projectile;
                    projectile.pierce *= 1.5f;
                }
            }
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
        }
    }

    public class SwordCharge : ModUpgrade<SaudaTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 5750;
        public override string Description => "Ability: dashes along the track dealing damage to bloons along the way.";
        public override string DisplayName => "Sword Charge";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var saudaLevel10 = Game.instance.model.towers.FirstOrDefault(t => t.name.Contains("Sauda") && t.tier == 10);
            if (saudaLevel10 != null)
            {
                var chargeBehavior = saudaLevel10.behaviors.FirstOrDefault(b => b.name.Contains("Charge"));
                if (chargeBehavior != null && chargeBehavior is AbilityModel)
                {
                    var chargeAbility = ((AbilityModel)chargeBehavior).Duplicate();
                    towerModel.AddBehavior(chargeAbility);
                }
            }
        }
    }

    public class Bladerunner : ModUpgrade<SaudaTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 22000;
        public override string Description => "Ability now dashes along the track 3 times.";
        public override string DisplayName => "Bladerunner";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var saudaLevel10 = Game.instance.model.towers.FirstOrDefault(t => t.name.Contains("Sauda") && t.tier == 10);
            var saudaLevel20 = Game.instance.model.towers.FirstOrDefault(t => t.name.Contains("Sauda") && t.tier == 20);

            if (saudaLevel10 != null && saudaLevel20 != null)
            {
                var oldBehavior = saudaLevel10.behaviors.FirstOrDefault(b => b.name.Contains("Charge"));
                var newBehavior = saudaLevel20.behaviors.FirstOrDefault(b => b.name.Contains("Charge"));

                if (oldBehavior != null && newBehavior != null &&
                    oldBehavior is AbilityModel && newBehavior is AbilityModel)
                {
                    var oldAbility = (AbilityModel)oldBehavior;
                    var newAbility = ((AbilityModel)newBehavior).Duplicate();

                    towerModel.RemoveBehavior(oldAbility);
                    towerModel.AddBehavior(newAbility);
                }
            }

            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                var projectile = attack.weapons[0].projectile;
                var damageModel = projectile.GetDamageModel();
                if (damageModel != null)
                {
                    damageModel.damage = 10;
                }
            }
        }
    }
}
