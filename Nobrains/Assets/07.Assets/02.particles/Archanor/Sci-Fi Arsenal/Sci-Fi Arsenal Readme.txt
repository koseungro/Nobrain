----------------------------------------
SCI-FI ARSENAL
----------------------------------------

1. Introduction
2. Spawning effects
3. Scaling effects
4. FAQ / Problemsolving
5. Asset Extras
6. Contact
7. Credits

----------------------------------------
1. INTRODUCTION
----------------------------------------

Effects can be found in the 'Sci-Fi Arsenal/Sci-Fi Effects/Prefabs' folder. Here they are sorted in 3 main categories: Combat, Environment and Interactive.

----------------------------------------
2. SPAWNING EFFECTS
----------------------------------------

In some cases you can just drag&drop the effect into the scene, otherwise you can spawn them via scripting.

Small example on spawning an explosion via script:

public Vector3 effectNormal;

spawnEffect = Instantiate(spawnEffect, transform.position, Quaternion.FromToRotation(Vector3.up, effectNormal)) as GameObject;

----------------------------------------
3. SCALING
----------------------------------------

To scale an effect in the scene, you can simply use the default Scaling tool (Hotkey 'R'). You can also select the effect and set the Scale in the Hierarchy.

Please remember that some parts of the effects such as Point Lights, Trail Renderers and Audio Sources may have to be manually adjusted afterwards.

----------------------------------------
4. FAQ / Problemsolving
----------------------------------------

Q: Particles appear stretched or too thin after scaling
 
A: This means that one of the effects are using a Stretched Billboard render type. Select the prefab and locate the Renderer tab at the bottom of the Particle System. If you scaled the effect up to be twice as big, you'll also need to multiply the current Length Scale by two.

--------------------

Q: The effects look grey or darker than they're supposed to

A: https://forum.unity.com/threads/epic-toon-fx.390693/#post-3279824

--------------------

Q: Annoying "Invalid AABB aabb" errors

A: This seems to be an error that comes and goes in between some versions, possible fix: https://forum.unity.com/threads/epic-toon-fx.390693/#post-3542039

--------------------

Q: I can't find what I'm looking for

A: There are a lot of effects in this pack, I suggest searching the Project folder or send an e-mail if you need a hand.

--------------------

Q: Can you add X effect to this asset?

A: Maybe! Add sufficient details to your request, and I will consider including it for the next update. Please note that it can take weeks or months in between updates.

----------------------------------------
5. ASSET EXTRAS
----------------------------------------

In the Sci-Fi Arsenal/Sci-Fi Effects/Scripts' folder you can find some neat scripts that may further help you customize the effects.

SciFiBeamStatic - A scripted beam effect. Uses prefabs from the 'Prefabs/Combat/Beam/Setup' folder

SciFiLightFade - This lets you fade out lights which are useful for explosions

SciFiLightFlicker - This script will make real-time lights flicker and pulsate

SciFiPitchRandomizer - A handy script for varying the pitch sound of sound effects to make them less repetetive

SciFiRotation - A simple script that applies constant rotation to an object

----------------------------------------
6. CONTACT
----------------------------------------

Need help with anything? 

E-Mail : archanor.work@gmail.com
Website: archanor.com

Follow me on Twitter for regular updates and news

Twitter: @Archanor

----------------------------------------
7. CREDITS
----------------------------------------

Special thanks to:

Jan J�rgensen