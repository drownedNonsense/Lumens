using UnityEngine;
using TMPro;
using Lumens.Singletons;


namespace Lumens.Menus {
/// <summary> Handles button styling. </summary>
public class ButtonStyling : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        private string          value;
        private TextMeshProUGUI textMesh;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Awake() {
            this.textMesh = this.GetComponent<TextMeshProUGUI>();
            this.value    = this.textMesh.text;
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
                
        /// <summary> On click behaviour. </summary>
        public void OnClick() =>
            SoundManager.PlayClick(false);


        /// <summary> On hover enter behaviour. </summary>
        public void OnHoverEnter() {

            SoundManager.PlayReflection(false);
            CursorManager.SetHover(true);
            this.textMesh.text = ">" + this.value + "<";
            
        } // void ..


        /// <summary> On hover exit behaviour. </summary>
        public void OnHoverExit() {
            CursorManager.SetHover(false);
            this.textMesh.text = this.value;
        } // void ..

}} // namespace ..
