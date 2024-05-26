using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Unity;

using static BossHandlerNamespace.BossHandler;
using Harmony;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppSystem;
using Il2CppAssets.Scripts.Simulation.Bloons;
using System.Runtime.InteropServices;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Behaviors;

namespace BossHandlerNamespace
{


    internal class Bosses
    {

        class BossDisplay : ModDisplay
        {
            public override string BaseDisplay => Game.instance.model.GetBloon("Bad").display.guidRef;


            public override void ModifyDisplayNode(UnityDisplayNode node)
            { 
                foreach (var item in node.genericRenderers)
                {
                    item.SetMainTexture(ModContent.GetTexture<BossHandler>("badTextures"));
                }
            }

        }


        [HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
        public class TitleScreenInit
        {
            [HarmonyPostfix]

            public static void Postfix()
            {

                // Creates a blank boss. CreateBossBase creates a copy of a Bad with added boss properties.
                BloonModel blankBoss = CreateBossBase(20000, 1f);

                // Sets the display to BossDisplay
                blankBoss.ApplyDisplay<BossDisplay>();

                /* Registers the boss into BossHandler.

                When a bloon registered via BossRegistration spawns, it will run BossInit 
                allowing you to run any other code the Bloon needs and/or start a monobehavior

                If the isMainBoss property is set to true (its true by default), the boss UI will display the bosses display name, icon, and health.
                If the description property has text, you can toggle seeing the description ingame.

                If continueRounds is greater than 0, then rounds will continue to be sent while the boss is on screen
                up to the continueRounds value. For example, if the boss spawns on round 40 with a continueRounds value of 9,
                the boss will allow rounds to be sent until round 49 is reached. Rounds continue as normal once the boss is popped
                This value is 0 by default.

                The returned BossRegistration object can be altered further.

                SizeX/SizeY: Dimensions of the description box
                UsesExtraInfo: Adds extra UI info under the health bar.
                ExtraInfoIcon: The icon used for the extra UI
                ExtraInfoText: The initial text next to the extra UI icon.

                You can change the initial text anytime by changing bossPanel.extraText
                */

         

                BossRegisteration blankBossRegistration = new BossRegisteration(blankBoss, "BlankBoss", "Blank", true, "defaultIcon");
           
                // Spawns the boss on round 40 and clears all other Bloon spawns from that round unless "clearOtherSpawns" is set to false

                blankBossRegistration.SpawnOnRound(40);


             
            }


        }
        public static void BossInit(Bloon bloon, BloonModel bloonModel, BossRegisteration registration)
        {
            // This function runs when a boss is spawned. The parameters include the boss and its registration info
            // You can put code here to spawn minions, effects,  start a monobehavior, etc


      
        }

        [RegisterTypeInIl2Cpp]
        public class MonoBehaviorTemplate : MonoBehaviour
        {
            public Bloon boss;
     
            public MonoBehaviorTemplate() : base()
            {

            }
            public void Start()
            {



            }

            public void Update()
            {
             

                if(boss != null)
                {
                    // If the boss is active, do stuff
                }
                else
                {
                    // If the bloon is destroyed, end this Monobehavior. 
                    this.Destroy();
                }
            }


        }


    }


    
}
