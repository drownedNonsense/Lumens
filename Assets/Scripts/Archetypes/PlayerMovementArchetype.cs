public class PlayerMovementArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public MovementData  data          { get; private set; }
        public SelectionData selectionData { get; private set; }


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void LoadComponents() {
            this.data          = this.GetComponent<MovementData>();
            this.selectionData = this.GetComponent<SelectionData>();
            this.gameObject.AddComponent<MovementInputSystem>();
        } // void ..
} // class ..
