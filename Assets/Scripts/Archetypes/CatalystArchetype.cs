using UnityEngine.Rendering.Universal;
using UnityEngine;
using Lumens.Data;


namespace Lumens.Archetypes {

[RequireComponent(typeof(CatalystData))]
[RequireComponent(typeof(PowerData))]
[RequireComponent(typeof(PowerSourceData))]
[RequireComponent(typeof(Light2D))]
[RequireComponent(typeof(Renderer))]
public class CatalystArchetype : Archetype<CatalystArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public CatalystData    data            { get; private set; }
        public PowerData       powerData       { get; private set; }
        public PowerSourceData powerSourceData { get; private set; }
        public new Light2D     light           { get; private set; }
        public new Renderer    renderer        { get; private set; }

        private const float LIGHT_INTENSITY = 1f;
        private const float LIGHT_RADIUS    = 8f;


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data            = this.gameObject.GetComponent<CatalystData>();
            this.powerData       = this.gameObject.GetComponent<PowerData>();
            this.powerSourceData = this.gameObject.GetComponent<PowerSourceData>();
            this.light           = this.gameObject.GetComponent<Light2D>();
            this.renderer        = this.gameObject.GetComponent<Renderer>();
        } // void ..


        public void TurnOn() {

            if (!this.powerData.isActivated)
                Level.IncreaseCatalystCount();

            this.renderer.material.color     = Generic.PlaneColor(this.data.planeLayer);
            this.light.color                 = Generic.PlaneColor(this.data.planeLayer);
            this.light.intensity             = CatalystArchetype.LIGHT_INTENSITY;
            this.light.pointLightOuterRadius = CatalystArchetype.LIGHT_RADIUS;

        } // void ..
}} // namespace ..
