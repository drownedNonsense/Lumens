using UnityEngine;
using UnityEngine.Rendering.Universal;


public class PlaneArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public Renderer[] renderers { get; private set; }
        public Light2D[]  lights    { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.renderers = this.GetComponentsInChildren<Renderer>();
            this.lights    = this.GetComponentsInChildren<Light2D>();
        } // void ..
} // class ..
