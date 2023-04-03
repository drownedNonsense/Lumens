using UnityEngine;


public class LaserData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        public int                power        = 1;
        public bool               fromCatalyst = false;
        public LaserArchetype     reflection   = null;
        public Generic.PlaneLayer planeLayer   = Generic.PlaneLayer.White;

        public float coolDown { get; private set; } = COOL_DOWN_TIME;

        public const float COOL_DOWN_TIME = 0.5f;
        
    
    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() =>
            this.coolDown = Mathf.Max(this.coolDown - Time.deltaTime, 0f);

        public void ResetCoolDown() =>
            this.coolDown = COOL_DOWN_TIME;

} // class ..
