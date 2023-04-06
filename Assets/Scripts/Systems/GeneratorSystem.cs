using UnityEngine;


/// <summary> Handles the Generator archetype. </summary>
public class GeneratorSystem : System<GeneratorArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

            private Controller controller;

            /// <summary> The amount of time every lasers can be reflected. </summary>
            public static int power { get; private set; } = 3;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {
            base.Awake();
            this.controller = this.GetComponentInParent<Controller>();
        } // void ..
            

        private void Update() {

            this.archetype.powerData.isPowered = this.archetype.selectionData.isActive;
            
            this.archetype.laserData.power =
                this.archetype.selectionData.isSelected && this.archetype.powerData.isActivated
                ? GeneratorSystem.power
                : 0;

            Camera.main.cullingMask = (int)this.CurrentPlane() << Generic.PLANE_MASK_OFFSET
                | Generic.SPECIAL_LAYER
                | Generic.FLOOR_LAYER
                | Generic.DEFAULT_LAYER;
        } // void ..
        

    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        /// <summary> Increases the power of all generator by multiplying it by 2. </summary>
        public static void IncreasePower() => GeneratorSystem.power <<= 1;


        /// <summary> Returns the plane of the last laser reflection coming from this generator. </summary>
        private Generic.PlaneLayer CurrentPlane() {
            return NextPlane(this.archetype.laserData);

            Generic.PlaneLayer NextPlane(LaserData laserData) {
                if (laserData.reflection) return NextPlane(laserData.reflection.data);
                else                      return laserData.planeLayer;
            } // PlaneLayer ..
        } // PlaneLayer ..
} // class ..
