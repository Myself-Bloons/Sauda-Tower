using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using MelonLoader;
using SaudaMod;

[assembly: MelonInfo(typeof(SaudaModMain), "Sauda Mod", "1.0.0", "Myself")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace SaudaMod
{
    public class SaudaModMain : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Sauda Mod loaded!");
        }
    }
 }
