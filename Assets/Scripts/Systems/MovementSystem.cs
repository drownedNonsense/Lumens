using UnityEngine;


/// <summary> Handles entity movement. </summary>
public class MovementSystem : System<MovingArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void FixedUpdate() {
            this.archetype
                .body
                .MovePosition(
                    (Vector2)this.transform.position
                    + this.archetype.data.translation
                    * Time.deltaTime);
            
            this.archetype
                .body
                .MoveRotation(
                    this.transform.eulerAngles.z
                    + this.archetype.data.rotation
                    * Time.deltaTime);
        } // void ..
} // class ..
