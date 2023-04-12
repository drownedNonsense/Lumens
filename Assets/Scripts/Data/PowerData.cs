using UnityEngine;


namespace Lumens.Data {
public class PowerData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/
    
        /// <summary> Is true when the entity is currently receiving power by a laser or another power source. </summary>
        public bool isPowered = false;

        /// <summary> Is true when the entity is powered. </summary>
        public bool isActivated = false;

        /// <summary> The entity's power won't turn off after the power source is disabled. </summary>
        public bool remainActivated = false;

}} // namespace ..
