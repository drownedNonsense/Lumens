using UnityEngine;
using UnityEngine.Rendering.Universal;


public class PlaneArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public Renderer[] renderers { get; private set; }
        public Light2D[]  lights    { get; private set; }


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void LoadComponents() {
            this.renderers = this.GetComponentsInChildren<Renderer>();
            this.lights    = this.GetComponentsInChildren<Light2D>();
        } // void ..
} // class ..
