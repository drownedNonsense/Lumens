using UnityEngine;


/// <summary> Handles player translation input into entity movemet. </summary>
public class TranslationInputSystem : System<PlayerTranslationArchetype> {

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


        private void Update() =>
            this.archetype.data.translation = Vector2.Lerp(
                this.archetype.data.translation,
                this.archetype.selectionData.isActive
                    ? this.controller.movement
                    : Vector2.zero,
                0.5f
            ); // Lerp()
} // class ..
