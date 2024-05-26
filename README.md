A boss mod template that re-uses the system from Boss Rush Recharged. Requires ModHelper

The template contains two class files, Bosses and BossHandler. 
Make your bosses in the Bosses file, while BossHandler handles all the UI elements. However you can alter BossHandler if you really need to.

-Register bosses so they will appear in the boss UI when they spawn.
-Can set names, icons, and descriptions for when they show up on the UI
-Optional additional info below the health bar. Can set an icon and text you can change at any moment.
-Triggers a BossInit function that runs when a boss spawns, so you can run your own code to supplement it. Whether its playing music or starting a Monobehavior.
-Adjust health and speed of bosses under ModSettings
-Monobehavior template
