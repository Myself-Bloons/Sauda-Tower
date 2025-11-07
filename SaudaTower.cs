using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.TowerSets;

namespace SaudaMod;

public class SaudaTower : ModTower
{
    public override string BaseTower => TowerType.Sauda;
    public override int Cost => 580;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 5;
    public override string Description => "A skilled warrior with a powerful sword.";
    public override TowerSet TowerSet => TowerSet.Primary;
    public override string DisplayName => "Sauda";
    public override string Icon => "Sauda-Icon";
    public override string Portrait => "Sauda-Portrait";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.RemoveBehavior<HeroModel>();
        towerModel.RemoveBehavior<CreateSoundOnBloonEnterTrackModel>();
        towerModel.RemoveBehavior<CreateSoundOnBloonLeakModel>();
        towerModel.RemoveBehavior<CreateSoundOnSelectedModel>();

        var abilities = towerModel.GetAbilities();
        if (abilities != null)
        {
            foreach (var ability in abilities)
            {
                towerModel.RemoveBehavior(ability);
            }
        }

        var attack = towerModel.GetAttackModel();
        if (attack != null)
        {
            if (attack.weapons != null && attack.weapons.Length > 0)
            {
                var weapon = attack.weapons[0];
                var projectile = weapon.projectile;

                projectile.RemoveBehavior<CreateProjectileOnExhaustFractionModel>();
                projectile.RemoveBehavior<DamageModifierForTagModel>();

                projectile.pierce = 5;
                projectile.maxPierce = 99999;
                projectile.CapPierce(99999);
                projectile.scale *= 2;
                projectile.radius *= 2;

                var damageModel = projectile.GetDamageModel();
                if (damageModel != null)
                {
                    damageModel.damage = 2;
                    damageModel.maxDamage = 9999;
                    damageModel.CapDamage(9999);
                }

                weapon.Rate = 1f;

                var ageModel = projectile.GetBehavior<AgeModel>();
                if (ageModel != null)
                {
                    ageModel.Lifespan = 0.1f;
                }
            }

            attack.range *= 0.8f;
        }

        towerModel.dontDisplayUpgrades = false;
        towerModel.towerSet = TowerSet.Primary;
    }

    public override bool IsValidCrosspath(int[] tiers)
    {
        if (ModHelper.HasMod("UltimateCrosspathing"))
        {
            return true;
        }
        return base.IsValidCrosspath(tiers);
    }
}

