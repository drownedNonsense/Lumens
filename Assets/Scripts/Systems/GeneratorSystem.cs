using UnityEngine;
using Lumens.Archetypes;
using Lumens.Data;


namespace Lumens.Systems {
/// <summary> Handles the Generator archetype. </summary>
public sealed class GeneratorSystem : System<GeneratorArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {

            this.archetype.powerData.isPowered = this.archetype.selectionData.isActive;
            this.archetype.laserData.transform.up = this.transform.up;
            
            this.archetype.laserData.power =
                this.archetype.selectionData.isSelected && this.archetype.powerData.isActivated
                ? Level.power
                : 0;

            Camera.main.cullingMask = (int)this.CurrentPlane() << Generic.PLANE_MASK_OFFSET
                | Generic.SPECIAL_LAYER
                | Generic.FLOOR_LAYER
                | Generic.DEFAULT_LAYER;
        } // void ..
        

    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        /// <summary> Returns the plane of the last laser reflection coming from this generator. </summary>
        private Generic.PlaneLayer CurrentPlane() {
            return NextPlane(this.archetype.laserData);

            Generic.PlaneLayer NextPlane(LaserData laserData) {
                if (laserData.reflection) return NextPlane(laserData.reflection.data);
                else                      return laserData.planeLayer;
            } // PlaneLayer ..
        } // PlaneLayer ..
}} // namespace ..
