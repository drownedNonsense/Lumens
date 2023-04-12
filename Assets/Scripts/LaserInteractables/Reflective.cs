using UnityEngine;
using Lumens.Singletons;
using Lumens.Archetypes;


namespace Lumens.Interactables {
public class Reflective : LaserInteractable {

    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        public override void OnPoweredStart(LaserArchetype laser, RaycastHit2D hit) {

            SoundManager.PlayReflection(false);
            if (laser.data.power > 1) {
                
                Vector2 dir = Vector2.Reflect(laser.transform.up, hit.normal);

                laser.data.reflection = LaserArchetype.NewInstance(
                    hit.point + dir * 0.001f,
                    dir,
                    laser.data.power - 1,
                    laser.data.planeLayer
                ); // NewInstance()
            } // if ..
        } // void ..


        public override void OnPowered(LaserArchetype laser, RaycastHit2D hit) {
            if (laser.data.power > 1 && laser.data.reflection) {

                Vector2 dir = Vector2.Reflect(laser.transform.up, hit.normal);

                laser.data.reflection.transform.position = hit.point + dir * 0.001f;
                laser.data.reflection.transform.up       = dir;
            } // if ..
        } // void ..
}} // namespace ..
