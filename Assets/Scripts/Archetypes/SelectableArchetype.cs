public class SelectableArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public SelectionData data { get; private set; }


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void LoadComponents() =>
            this.data = this.GetComponent<SelectionData>();
} // class ..
