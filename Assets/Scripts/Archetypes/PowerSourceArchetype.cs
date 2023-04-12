using UnityEngine;
using Lumens.Systems;
using Lumens.Data;


namespace Lumens.Archetypes {
[RequireComponent(typeof(PowerSourceData))]
[RequireComponent(typeof(PowerData))]
[RequireComponent(typeof(PowerSourceSystem))]
public class PowerSourceArchetype : Archetype<PowerSourceArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PowerSourceData data      { get; private set; }
        public PowerData       powerData { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data      = this.gameObject.GetComponent<PowerSourceData>();
            this.powerData = this.gameObject.GetComponent<PowerData>();
            this.system    = this.gameObject.GetComponent<PowerSourceSystem>();
        } // void ..
}} // namespace ..
