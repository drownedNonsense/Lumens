using UnityEngine;


public class MovingArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public MovementData data { get; private set; }
        public Rigidbody2D  body { get; private set; }


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void LoadComponents() {
            this.data = this.GetComponent<MovementData>();
            this.body = this.GetComponent<Rigidbody2D>();
            this.gameObject.AddComponent<MovementSystem>();
        } // void ..
} // class ..
