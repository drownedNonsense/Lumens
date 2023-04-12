using UnityEngine;
using Lumens.Systems;
using Lumens.Data;


namespace Lumens.Archetypes {
[RequireComponent(typeof(PowerData))]
[RequireComponent(typeof(PowerSystem))]
public class PowerArchetype : Archetype<PowerArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PowerData data { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data   = this.gameObject.GetComponent<PowerData>();
            this.system = this.gameObject.GetComponent<PowerSystem>();
        } // void ..
}} // namespace ..
