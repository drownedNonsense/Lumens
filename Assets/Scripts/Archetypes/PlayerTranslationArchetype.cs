public class PlayerTranslationArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public MovementData  data          { get; private set; }
        public SelectionData selectionData { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data          = this.GetComponent<MovementData>();
            this.selectionData = this.GetComponent<SelectionData>();
            this.gameObject.AddComponent<TranslationInputSystem>();
        } // void ..
} // class ..
