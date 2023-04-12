using UnityEngine;
using Lumens.Data;


namespace Lumens.Archetypes {
[RequireComponent(typeof(SelectionData))]
public class SelectableArchetype : Archetype<SelectableArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public SelectionData data { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() =>
            this.data = this.gameObject.GetComponent<SelectionData>();
            
}} // namespace ..
