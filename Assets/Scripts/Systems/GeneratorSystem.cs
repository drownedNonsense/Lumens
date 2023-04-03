using UnityEngine;


public class GeneratorSystem : System<GeneratorArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

            private Controller controller;

            public static int power { get; private set; } = 3;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {
            base.Awake();
            this.controller = this.GetComponentInParent<Controller>();
        } // void ..
            

        private void Update() {

            this.archetype.laserData.power = this.archetype.selectionData.isSelected
                ? GeneratorSystem.power
                : 0;

            Camera.main.cullingMask = (int)this.CurrentPlane() << Generic.PLANE_MASK_OFFSET
                | Generic.SPECIAL_LAYER
                | Generic.FLOOR_LAYER
                | Generic.DEFAULT_LAYER;
            
        } // void ..

        public static void IncreasePower() => GeneratorSystem.power <<= 1;
        private Generic.PlaneLayer CurrentPlane() {
            return NextPlane(this.archetype.laserData);

            Generic.PlaneLayer NextPlane(LaserData laserData) {
                if (laserData.reflection) return NextPlane(laserData.reflection.data);
                else                      return laserData.planeLayer;
            } // PlaneLayer ..
        } // PlaneLayer ..
} // class ..
