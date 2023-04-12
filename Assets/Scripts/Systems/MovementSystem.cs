using UnityEngine;
using Lumens.Singletons;
using Lumens.Archetypes;


namespace Lumens.Systems {
/// <summary> Handles entity movement. </summary>
public sealed class MovementSystem : System<MovingArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private const float SOUND_THRESHOLD = 0.2f;


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

            if (this.archetype.data.translation.x > Time.fixedDeltaTime * 0.5f
            || this.archetype.data.translation.y > Time.fixedDeltaTime * 0.5f
            || this.archetype.data.rotation > Time.fixedDeltaTime * 22.5f) 
                SoundManager.PlayCrunch(true);
                
        } // void ..
}} // namespace ..
