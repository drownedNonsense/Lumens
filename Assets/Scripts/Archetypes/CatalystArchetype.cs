using UnityEngine.Rendering.Universal;


public class CatalystArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public CatalystData data  { get; private set; }
        public new Light2D  light { get; private set; }

        private const float LIGHT_INTENSITY = 1f;
        private const float LIGHT_RADIUS    = 8f;


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data  = this.GetComponent<CatalystData>();
            this.light = this.GetComponent<Light2D>();
        } // void ..


        public void TurnOn() {
            GeneratorSystem.IncreasePower();
            this.light.intensity             = CatalystArchetype.LIGHT_INTENSITY;
            this.light.pointLightOuterRadius = CatalystArchetype.LIGHT_RADIUS;
        } // void ..
} // class ..
