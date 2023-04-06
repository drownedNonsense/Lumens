using UnityEngine;


/// <summary> Handles entity movement along a path. </summary>
public class PathMovementSystem : System<PathMovementArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private const float ROTATION_SPEED    = 22.5f;
        private const float TRANSLATION_SPEED = 1f;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {

            if (this.archetype.powerData.isActivated) {
                
                if (this.archetype.data.hasReachedTheNextNode) {
                    if (this.archetype.data.movesForward) this.archetype.data.currentNodeIndex++;
                    else                                  this.archetype.data.currentNodeIndex--;
                } // if ..


                if (this.archetype.data.isAtTheEnd && this.archetype.data.loop)
                    this.archetype.data.movesForward = !this.archetype.data.movesForward;


                Vector2 posOffset = this.archetype
                    .data
                    .nextNode
                    .position
                - this.transform.position;

                this.archetype
                    .movementData
                    .translation = posOffset.normalized * PathMovementSystem.TRANSLATION_SPEED;


                float rotationOffset = this.archetype
                    .data
                    .nextNode
                    .eulerAngles
                    .z
                - this.transform.eulerAngles.z;

                this.archetype
                    .movementData
                    .rotation = Mathf.Clamp(
                        rotationOffset,
                        -PathMovementSystem.ROTATION_SPEED,
                        PathMovementSystem.ROTATION_SPEED);

            } else {

                this.archetype.movementData.translation = Vector2.zero;
                this.archetype.movementData.rotation    = 0f;

            } // if ..
        } // void ..
} // class ..
