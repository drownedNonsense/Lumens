using UnityEngine;


public class MovementInputSystem : System<PlayerMovementArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private Controller controller;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {
            base.Awake();
            this.controller = this.GetComponentInParent<Controller>();
        } // void ..


        private void Update() {
            
            this.archetype.data.translation = Vector2.Lerp(
                this.archetype.data.translation,
                this.archetype.selectionData.isActive
                    ? this.controller.movement * Time.deltaTime
                    : Vector2.zero,
                0.5f
            ); // Lerp()

            this.archetype.data.rotation = Mathf.Lerp(
                this.archetype.data.rotation,
                this.archetype.selectionData.isActive
                    ? this.controller.z * 22.5f * Time.deltaTime
                    : 0f,
                0.5f
            ); // Lerp()
        } // void ..
} // class ..
