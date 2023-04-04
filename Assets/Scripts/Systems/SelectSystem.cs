using UnityEngine;


/// <summary> Handles selection. </summary>
public class SelectSystem : StaticSystem<SelectableArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private static Controller controller;
        private static Camera mainCamera;
        private static Texture2D cursor;
        private static Texture2D cursorSelect;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {
            base.Awake();
            SelectSystem.controller   = this.GetComponentInParent<Controller>();
            SelectSystem.mainCamera   = Camera.main;
            SelectSystem.cursor       = Resources.Load<Texture2D>("cursor");
            SelectSystem.cursorSelect = Resources.Load<Texture2D>("cursorSelect");
        } // void ..


        private void Update() {

            RaycastHit2D hit = Physics2D.Raycast(
                SelectSystem.mainCamera.ScreenToWorldPoint(SelectSystem.controller.selection),
                Vector2.zero,
                0f,
                Generic.TARGET_LAYER
            ); // Raycast()


            if (hit) Cursor.SetCursor(cursorSelect, new Vector2(4f, 4f), CursorMode.Auto);
            else     Cursor.SetCursor(cursor,       new Vector2(4f, 4f), CursorMode.Auto);


            if (SelectSystem.controller.a.up && SelectSystem.controller.shift) {
                foreach (SelectableArchetype selectable in this.archetypes)
                    selectable.data.isActive = false;

                if (hit) {

                    SelectionData selectionData = hit.transform.GetComponent<SelectionData>();
                    selectionData.isActive   = true;
                    selectionData.isSelected = !selectionData.isSelected;

                } // if ..
            } // if ..
        } // void ..
} // class ..
