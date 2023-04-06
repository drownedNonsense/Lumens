using UnityEngine;


public class Prism : LaserInteractable {

    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        public override void OnPoweredStart(LaserArchetype laser, RaycastHit2D hit) {
            if (laser.data.power > 1)
                laser.data.reflection = LaserArchetype.NewInstance(
                    hit.collider.ClosestPoint(hit.transform.position + hit.transform.up)
                    + (Vector2)hit.transform.up * 0.001f,
                    hit.transform.up,
                    laser.data.power - 1,
                    laser.data.planeLayer
                ); // NewInstance()
        } // void ..


        public override void OnPowered(LaserArchetype laser, RaycastHit2D hit) {
            if (laser.data.power > 1) {

                laser.data
                    .reflection
                    .transform
                    .position = hit.collider.ClosestPoint(hit.transform.position + hit.transform.up)
                        + (Vector2)hit.transform.up * 0.001f;

                laser.data
                    .reflection
                    .transform
                    .up = hit.transform.up;
                    
            } // if ..
        } // void ..
} // class ..
