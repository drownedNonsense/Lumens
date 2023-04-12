using UnityEngine;
using Lumens.Systems;
using Lumens.Data;


namespace Lumens.Archetypes {
[RequireComponent(typeof(PathData))]
[RequireComponent(typeof(MovementData))]
[RequireComponent(typeof(PowerData))]
[RequireComponent(typeof(PathMovementSystem))]
public class PathMovementArchetype : Archetype<PathMovementArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public PathData         data         { get; private set; }
        public MovementData     movementData { get; private set; }
        public PowerData        powerData    { get; private set; }
        public new LineRenderer renderer     { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() {
            this.data         = this.gameObject.GetComponent<PathData>();
            this.movementData = this.gameObject.GetComponent<MovementData>();
            this.powerData    = this.gameObject.GetComponent<PowerData>();
            this.renderer     = this.gameObject.TryAddComponentInChildren<LineRenderer>(Resources.Load<GameObject>("Prefabs/Rail"));
            this.system       = this.gameObject.GetComponent<PathMovementSystem>();
        } // void ..
}} // namespace ..
