using UnityEngine;
using Lumens.Archetypes;


namespace Lumens.Data {
public class LaserData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        /// <summary> The number of times a laser can be reflected. </summary>
        public int power = 1;

        /// <summary> The collider's tag. </summary>
        public LaserInteractable laserInteractable = null;

        /// <summary> A reference to the laser's reflection. </summary>
        public LaserArchetype reflection = null;

        /// <summary> A layer indicating which higher planes the laser is intersecting with. </summary>
        public Generic.PlaneLayer planeLayer = Generic.PlaneLayer.White;

        /// <summary> The remaining time until the laser can be reflected again. </summary>
        public float coolDown { get; private set; } = COOL_DOWN_TIME;


        public const float COOL_DOWN_TIME = 0.5f;
        
    
    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() =>
            this.coolDown = Mathf.Max(this.coolDown - Time.deltaTime, 0f);


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        /// <summary> Sets the laser's cooldown to COOL_DOWN_TIME (0.5 by default). </summary>
        public void ResetCoolDown() =>
            this.coolDown = COOL_DOWN_TIME;

}} // namespace ..
