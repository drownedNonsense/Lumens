public class PowerSourceArchetype : Archetype {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PowerSourceData data      { get; private set; }
        public PowerData       powerData { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data      = this.GetComponent<PowerSourceData>();
            this.powerData = this.GetComponent<PowerData>();
            this.gameObject.AddComponent<PowerSourceSystem>();
        } // void ..
} // class ..
