using UnityEngine;
using Lumens.Singletons;
using Lumens.Archetypes;
using Lumens.Data;


namespace Lumens.Systems {
/// <summary> Handles selection. </summary>
public sealed class SelectSystem : StaticSystem<SelectableArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private static Camera mainCamera;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {
            base.Awake();
            SelectSystem.mainCamera = Camera.main;
        } // void ..


        private void Update() {

            RaycastHit2D hit = Physics2D.Raycast(
                SelectSystem.mainCamera.ScreenToWorldPoint(Controller.selection),
                Vector2.zero,
                0f,
                Generic.TARGET_LAYER
            ); // Raycast()


            CursorManager.SetHover(hit);
            if (Controller.a.up && Controller.shift) {
                foreach (SelectableArchetype selectable in this.archetypes)
                    selectable.data.isActive = false;

                if (hit) {

                    SoundManager.PlayClick(false);
                    SelectionData selectionData = hit.transform.GetComponent<SelectionData>();
                    selectionData.isActive   = true;
                    selectionData.isSelected = !selectionData.isSelected;

                } // if ..
            } // if ..
        } // void ..
}} // namespace ..
