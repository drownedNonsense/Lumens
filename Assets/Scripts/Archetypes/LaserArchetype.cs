using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LaserArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public     LaserData    data     { get; private set; }
        public new LineRenderer renderer { get; private set; }
        public new Light2D      light    { get; private set; }

        private const float WIDTH           = 1f;
        private const int   RENDERING_LAYER = 2;
        private const int   DEFAULT_POWER   = 1;


    /*#######################*/
    /* C O N S T R U C T O R */
    /*#######################*/
        
        public static LaserArchetype NewInstance(
            Vector2 origin,
            Vector2 dir,
            int                power = DEFAULT_POWER,
            Generic.PlaneLayer plane = Generic.PlaneLayer.White
        ) {

            LaserArchetype laser = LaserArchetype.Instantiate(Resources.Load<LaserArchetype>("Entities/Laser"));

            laser.data = laser.GetComponent<LaserData>();
            laser.data.transform.position = origin;
            laser.data.transform.up       = dir;
            laser.data.power              = power;
            laser.data.planeLayer         = plane;
            laser.renderer = laser.GetComponent<LineRenderer>();
            laser.Awake();

            return laser;

        } // Laser ..


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {
            base.Awake();
            this.renderer.startWidth   = WIDTH;
            this.renderer.endWidth     = WIDTH;
            this.renderer.sortingOrder = RENDERING_LAYER;
            this.renderer.startColor   = Generic.PlaneColor(this.data.planeLayer);
            this.renderer.endColor     = Generic.PlaneColor(this.data.planeLayer);
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() {
            this.data     = this.GetComponent<LaserData>();
            this.renderer = this.GetComponent<LineRenderer>();
            this.light    = this.GetComponentInChildren<Light2D>();
            this.gameObject.AddComponent<LaserSystem>();
        } // void ..        
} // class ..
