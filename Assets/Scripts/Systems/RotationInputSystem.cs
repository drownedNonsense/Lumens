using UnityEngine;


/// <summary> Handles player input into entity movemet. </summary>
public class RotationInputSystem : System<PlayerRotationArchetype> {

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
            this.archetype.data.rotation = Mathf.Lerp(
                this.archetype.data.rotation,
                this.archetype.selectionData.isActive
                    ? this.controller.z * 22.5f
                    : 0f,
                0.5f
            ); // Lerp()
} // class ..
