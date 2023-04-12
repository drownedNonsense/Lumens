using UnityEngine;
using Lumens.Systems;
using Lumens.Data;


namespace Lumens.Archetypes {
[RequireComponent(typeof(PowerData))]
[RequireComponent(typeof(SelectionData))]
[RequireComponent(typeof(GeneratorSystem))]
public class GeneratorArchetype : Archetype<GeneratorArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public LaserData     laserData     { get; private set; }
        public PowerData     powerData     { get; private set; }
        public SelectionData selectionData { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() {
            this.laserData     = this.gameObject.TryAddComponentInChildren<LaserData>(Resources.Load<GameObject>("Prefabs/Laser"));
            this.powerData     = this.gameObject.GetComponent<PowerData>();
            this.selectionData = this.gameObject.GetComponent<SelectionData>();
            this.system        = this.gameObject.GetComponent<GeneratorSystem>();
        } // void ..
}} // namespace ..
