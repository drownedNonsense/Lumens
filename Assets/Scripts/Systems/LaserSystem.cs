using System.Collections;
using UnityEngine;
using Lumens.Archetypes;


namespace Lumens.Systems {
/// <summary> Handles the Laser archetype. </summary>
public sealed class LaserSystem : System<LaserArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private const int   RANGE           = 100;
        private const float LIGHT_INTENSITY = 2f;
        private const float LIGHT_RADIUS    = 2f;
        private const float LIGHT_WAVING    = 4f;
        private const float LIGHT_VARIANCE  = 0.25f;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {

            if (this.archetype.data.power != 0) this.Shoot();
            else this.archetype.renderer.positionCount = 0;

            UpdateReflections(this.archetype);

        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        /// <summary> Updates a laser's reflections. </summary>
        private static void UpdateReflections(LaserArchetype laser) {
            if (laser.data.reflection) {

                UpdateReflections(laser.data.reflection);
                laser.data.reflection.data.power = laser.data.power - 1;
            
            } // if ..


            if (laser.data.power < 1 || !laser.data.laserInteractable)
                if (laser.data.reflection)
                    Destroy(laser.data.reflection.gameObject);

        } // void ..


        /// <summary> Handle the laser's shooting behaviour. </summary>
        private void Shoot() {

            RaycastHit2D hit = Physics2D.Raycast(
                this.transform.position,
                this.transform.up,
                LaserSystem.RANGE,
                (int)this.archetype.data.planeLayer << Generic.PLANE_MASK_OFFSET | Generic.SPECIAL_LAYER
            ); // Raycast()


            this.archetype.renderer.positionCount = 2;
            this.archetype.renderer.SetPositions(new Vector3[] {this.transform.position, hit.point});


            if (hit) {

                this.archetype.light.transform.position = hit.point;
                this.archetype.light.color = Generic.PlaneColor(this.archetype.data.planeLayer);
                this.archetype.light.pointLightInnerRadius = 1f;
                this.archetype.light.pointLightOuterRadius = LaserSystem.LIGHT_RADIUS
                    + Mathf.Sin(Time.time * LaserSystem.LIGHT_WAVING)
                    * LaserSystem.LIGHT_VARIANCE;


                bool newLaser = false;
                if (this.archetype.data.laserInteractable) {
                    if (this.archetype.data.laserInteractable.gameObject == hit.collider.gameObject) {
                        this.archetype.data.laserInteractable.OnPowered(this.archetype, hit);

                    } else newLaser = true;
                } else newLaser = true;


                if (newLaser) {

                    if (this.archetype.data.reflection)
                        Destroy(this.archetype.data.reflection.gameObject);


                    if (hit.collider.TryGetComponent<LaserInteractable>(
                        out this.archetype.data.laserInteractable
                    )) {

                        this.StartCoroutine(World.Shake());
                        this.archetype.data.laserInteractable.OnPoweredStart(this.archetype, hit);

                        if (this.archetype.data.reflection)
                            this.archetype.data.reflection.transform.parent = this.transform;

                    } // if ..
                } // if ..
            } // if ..
        } // void .. 
}} // namespace ..
