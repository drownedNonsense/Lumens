public class GeneratorArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public LaserData     laserData     { get; private set; }
        public SelectionData selectionData { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() {
            this.laserData     = this.GetComponentInChildren<LaserData>();
            this.selectionData = this.GetComponent<SelectionData>();
            this.gameObject.AddComponent<GeneratorSystem>();
        } // void ..
} // class ..
