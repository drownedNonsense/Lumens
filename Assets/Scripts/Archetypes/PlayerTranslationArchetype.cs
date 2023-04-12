using UnityEngine;
using Lumens.Systems;
using Lumens.Data;


namespace Lumens.Archetypes {
[RequireComponent(typeof(MovementData))]
[RequireComponent(typeof(SelectionData))]
[RequireComponent(typeof(TranslationInputSystem))]
public class PlayerTranslationArchetype : Archetype<PlayerTranslationArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public MovementData  data          { get; private set; }
        public SelectionData selectionData { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        protected override void InitComponents() {
            this.data          = this.gameObject.GetComponent<MovementData>();
            this.selectionData = this.gameObject.GetComponent<SelectionData>();
            this.system        = this.gameObject.GetComponent<TranslationInputSystem>();
        } // void ..
}} // namespace ..
