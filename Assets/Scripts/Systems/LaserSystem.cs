using System.Collections;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine;


/// <summary> Handles the Laser archetype. </summary>
public class LaserSystem : System<LaserArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private const int   RANGE = 100;
        private const float DEFAULT_EFFECT_INTENSITY = 0.2f;
        private const float LIGHT_INTENSITY = 2f;
        private const float LIGHT_RADIUS    = 2f;
        private const float LIGHT_WAVING    = 4f;
        private const float LIGHT_VARIANCE  = 0.25f;

        private ChromaticAberration effect;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {

            base.Awake();
            VolumeProfile profile = Resources.Load<VolumeProfile>("VolumeProfile");

            for (int i = 0; i < profile.components.Count; i++)
                if (profile.components[i].name == "ChromaticAberration")
                    this.effect = (ChromaticAberration)profile.components[i];

        } // void ..


        private void Update() {

            if (this.archetype.data.power != 0) this.Shoot();
            else this.archetype.renderer.positionCount = 0;

            ApplyCascading(this.archetype);

        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        /// <summary> Updates the laser's and its reflection's power by recursion. </summary>
        private static void ApplyCascading(LaserArchetype laser) {
            if (laser.data.reflection) {

                ApplyCascading(laser.data.reflection);
                laser.data.reflection.data.power = laser.data.power - 1;
                
            } // if ..

            if (laser.data.power < 0)
                Destroy(laser.gameObject);

        } // void ..


        /// <summary> Handle the laser's shooting behaviour. </summary>
        private void Shoot() {

            RaycastHit2D hit = Physics2D.Raycast(
                this.transform.position,
                this.transform.up,
                LaserSystem.RANGE,
                (int)this.archetype.data.planeLayer << Generic.PLANE_MASK_OFFSET | Generic.SPECIAL_LAYER
            ); // Raycast()


            if (hit) {
                this.archetype.light.transform.position = hit.point;
                this.archetype.light.color = Generic.PlaneColor(this.archetype.data.planeLayer);
                this.archetype.light.pointLightInnerRadius = 1f;
                this.archetype.light.pointLightOuterRadius = LaserSystem.LIGHT_RADIUS
                    + Mathf.Sin(Time.time * LaserSystem.LIGHT_WAVING)
                    * LaserSystem.LIGHT_VARIANCE;
            } // if ..
            

            this.archetype.renderer.positionCount = 2;
            this.archetype.renderer.SetPositions(new Vector3[] {this.transform.position, hit.point});


            if (this.archetype.data.power > 1 && hit.collider) {

                string[] tagArguments = hit.collider.tag.Split(' ');
                switch (tagArguments[0]) {
                    case ("Reflective"): {

                        Vector2 dir    = Vector2.Reflect(this.transform.up, hit.normal);
                        Vector2 origin = hit.point + dir * 0.001f;
                        

                        this.UpdateReflection(
                            origin,
                            dir,
                            false,
                            this.archetype.data.planeLayer,
                            hit.collider.gameObject
                        ); // UpdateReflection()

                        break;

                    } case ("Prism"): {

                        Vector2 outerSide = hit.collider.ClosestPoint(hit.point + (Vector2)hit.transform.up);
                        Vector2 origin    = outerSide + (outerSide -(Vector2)hit.transform.position).normalized * 0.001f;
                        

                        this.UpdateReflection(
                            origin,
                            hit.transform.up,
                            false,
                            this.archetype.data.planeLayer,
                            hit.collider.gameObject
                        ); // UpdateReflection()

                        break;

                    } case ("Catalyst"): {

                        Vector2 outerSide = hit.collider.ClosestPoint(hit.point + (Vector2)this.transform.up);
                        Vector2 origin    = outerSide + (outerSide -(Vector2)hit.transform.position).normalized * 0.001f;
                        Generic.PlaneLayer catalystPlane = tagArguments[1] switch {
                            "Red"    => Generic.PlaneLayer.Red,
                            "Yellow" => Generic.PlaneLayer.Yellow,
                            "Blue"   => Generic.PlaneLayer.Blue,
                            _        => Generic.PlaneLayer.White,
                        }; // Generic.PlaneType ..


                        if (this.archetype.data.reflection)
                            if (!this.archetype.data.reflection.data.fromCatalyst)
                                this.archetype.data.reflection.data.power = -1;


                        this.UpdateReflection(
                            origin,
                            this.transform.up,
                            true,
                            (Generic.PlaneLayer)(
                                (int)this.archetype.data.planeLayer
                                ^ ((int)catalystPlane & ~1)),
                            hit.collider.gameObject
                        ); // UpdateReflection()


                        break;

                    } default: {

                        if (this.archetype.data.reflection) this.archetype.data.reflection.data.power = -1;
                        break;

                    } // default
                } // switch ..
            } // if ..
        } // void .. 


        /// <summary> Update the laser's reflection. </summary>
        private void UpdateReflection(
            Vector2 origin,
            Vector2 dir,
            bool    fromCatalyst,
            Generic.PlaneLayer plane,
            GameObject collider
        ) {
            if (this.archetype.data.reflection) {

                this.archetype.data.reflection.transform.position  = origin;
                this.archetype.data.reflection.transform.up        = dir;
                this.archetype.data.reflection.data.planeLayer     = plane;
                this.archetype.data.reflection.renderer.startColor = Generic.PlaneColor(plane);
                this.archetype.data.reflection.renderer.endColor   = Generic.PlaneColor(plane);
                this.archetype.data.reflection.data.fromCatalyst   = fromCatalyst;

            } else if (this.archetype.data.coolDown == 0f) {
                if (fromCatalyst) {

                    CatalystArchetype catalyst = collider.GetComponent<CatalystArchetype>();

                    if (!catalyst.data.isLit) catalyst.TurnOn();
                    catalyst.data.isLit = true;

                } // if ..



                this.StartCoroutine("Shake");
                this.archetype.data.ResetCoolDown();
                this.archetype.data.reflection = LaserArchetype.NewInstance(
                    origin,
                    dir,
                    this.archetype.data.power,
                    plane
                ); // Instantiate()
            } // if ..


            if (this.archetype.data.reflection)
                this.archetype.data.reflection.data.fromCatalyst = fromCatalyst;

        } // void ..


        /// <summary> A coroutine that applies a 'glitch' or shake effect to the camera. </summary>
        private IEnumerator Shake() {
            for (int i = 0; i < 10; i++) {
                this.effect.intensity.value = DEFAULT_EFFECT_INTENSITY + i * 0.05f;
                yield return new WaitForSeconds(0.01f);;
            } // for ..

            this.effect.intensity.value = DEFAULT_EFFECT_INTENSITY;
        } // void ..
} // class ..
