public class SelectableArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public SelectionData data { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() =>
            this.data = this.GetComponent<SelectionData>();
} // class ..
