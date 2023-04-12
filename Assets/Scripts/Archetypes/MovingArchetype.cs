using UnityEngine;
using Lumens.Systems;
using Lumens.Data;


namespace Lumens.Archetypes {
[RequireComponent(typeof(MovementData))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MovementSystem))]
public class MovingArchetype : Archetype<MovingArchetype> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public MovementData data { get; private set; }
        public Rigidbody2D  body { get; private set; }


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        protected override void InitComponents() {
            this.data   = this.gameObject.GetComponent<MovementData>();
            this.body   = this.gameObject.GetComponent<Rigidbody2D>();
            this.system = this.gameObject.GetComponent<MovementSystem>();
        } // void ..
}} // namespace ..
