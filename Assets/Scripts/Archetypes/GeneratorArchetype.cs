public class GeneratorArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public LaserData     laserData     { get; private set; }
        public SelectionData selectionData { get; private set; }


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void LoadComponents() {
            this.laserData     = this.GetComponentInChildren<LaserData>();
            this.selectionData = this.GetComponent<SelectionData>();
            this.gameObject.AddComponent<GeneratorSystem>();
        } // void ..
} // class ..
