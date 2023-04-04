using UnityEngine;


public class MovingArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public MovementData data { get; private set; }
        public Rigidbody2D  body { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() {
            this.data = this.GetComponent<MovementData>();
            this.body = this.GetComponent<Rigidbody2D>();
            this.gameObject.AddComponent<MovementSystem>();
        } // void ..
} // class ..
