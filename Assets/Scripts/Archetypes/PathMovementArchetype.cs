using UnityEngine;


public class PathMovementArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PathData     data         { get; private set; }
        public MovementData movementData { get; private set; }
        public PowerData    powerData    { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() {
            this.data         = this.GetComponent<PathData>();
            this.movementData = this.GetComponent<MovementData>();
            this.powerData    = this.GetComponent<PowerData>();
            this.gameObject.AddComponent<PathMovementSystem>();
        } // void ..
} // class ..
