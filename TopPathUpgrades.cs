using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2Cpp;

namespace SaudaMod.Upgrades
{
    public class LaserSword : ModUpgrade<SaudaTower>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 700;
        public override string Description => "Sword does extra damage and can pop leads.";
        public override string DisplayName => "Laser Sword";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                var projectile = attack.weapons[0].projectile;
                var damageModel = projectile.GetDamageModel();
                if (damageModel != null)
                {
                    damageModel.damage += 2;
                    damageModel.immuneBloonProperties = BloonProperties.Purple;
                }
            }
        }
    }

    public class PlasmaSword : ModUpgrade<SaudaTower>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 750;
        public override string Description => "Blade forged from plasma does even more damage.";
        public override string DisplayName => "Plasma Sword";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null && attack.weapons.Length > 0)
            {
                var projectile = attack.weapons[0].projectile;
                var damageModel = projectile.GetDamageModel();
                if (damageModel != null)
                {
                    damageModel.damage += 3;
                }
            }
        }
    }

    public class FiringSword : ModUpgrade<SaudaTower>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 1200;
        public override string Description => "Souda's sword fires out lasers.";
        public override string DisplayName => "Firing Sword";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null)
            {
                var dartlingModel = Game.instance.model.GetTowerFromId("DartlingGunner-300");
                if (dartlingModel != null)
                {
                    var laserWeapon = dartlingModel.GetAttackModel().weapons[0].Duplicate();
                    laserWeapon.projectile.RemoveBehavior<AddBehaviorToBloonModel>();
                    laserWeapon.projectile.pierce = 10;
                    laserWeapon.projectile.GetDamageModel().damage = 3;
                    laserWeapon.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
                    laserWeapon.rate = 0.5f;
                    attack.AddWeapon(laserWeapon);
                }
            }
        }
    }

    public class LaserShock : ModUpgrade<SaudaTower>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 2000;
        public override string Description => "Sword inflicts a laser shock.";
        public override string DisplayName => "Laser Shock";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null)
            {
                if (attack.weapons.Length >= 2)
                {
                    var laserWeapon = attack.weapons[1];
                    laserWeapon.projectile.pierce = 5;
                    laserWeapon.projectile.GetDamageModel().damage = 4;
                    laserWeapon.rate = 0.5f;
                }
                else
                {
                    var dartlingModel = Game.instance.model.GetTowerFromId("DartlingGunner-300");
                    if (dartlingModel != null)
                    {
                        var laserWeapon = dartlingModel.GetAttackModel().weapons[0].Duplicate();
                        laserWeapon.projectile.RemoveBehavior<AddBehaviorToBloonModel>();
                        laserWeapon.projectile.pierce = 5;
                        laserWeapon.projectile.GetDamageModel().damage = 4;
                        laserWeapon.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
                        laserWeapon.rate = 0.5f;
                        attack.AddWeapon(laserWeapon);
                    }
                }

                attack.range *= 1.2f;
                towerModel.range *= 1.2f;
                towerModel.radius *= 1.2f;
            }
        }
    }

    public class RapidfireBlade : ModUpgrade<SaudaTower>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 54500;
        public override string Description => "Lasers fire out at incredible speeds.";
        public override string DisplayName => "Rapidfire Blade";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attack = towerModel.GetAttackModel();
            if (attack != null)
            {
                if (attack.weapons.Length >= 2)
                {
                    attack.weapons[0].rate = 0.25f;
                    attack.weapons[1].rate = 0.025f;
                    attack.weapons[1].projectile.GetDamageModel().damage = 7;
                    attack.weapons[1].projectile.pierce = 10;
                }

                attack.range *= 1.5f;
                towerModel.range *= 1.5f;
                towerModel.radius *= 1.5f;
            }
        }
    }
}
