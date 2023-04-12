using UnityEngine;


namespace Lumens.Data {
public class MovementData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/
    
        /// <summary> The amount of translation the entity moves each frame. </summary>
        public Vector2 translation = Vector2.zero;

        /// <summary> The amount of rotation the entity rotates each frame. </summary>
        public float rotation = 0f;

}} // namespace ..
