using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace Lumens.Singletons {
/// <summary> Handles screen fading. </summary>
public sealed class Fade : Singleton<Fade> {
    
    /*#########*/
    /* D A T A */
    /*#########*/

        private Image _mask;
        private bool  _isFading;

        public static bool isFading => Fade.instance._isFading;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/
        
        protected override void Awake() {
            base.Awake();
            this._mask = GameObject.FindGameObjectWithTag("UIFade").GetComponent<Image>();
        } // void ..


        private void Start() =>
            StartCoroutine(Fade.FadeIn());


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
        
        /// <summary> A coroutine that fades the current screen to clear. </summary>
        public static IEnumerator FadeIn() {

            Color fadeColor = Fade.instance._mask.color;
            fadeColor.a              = 1f;
            Fade._instance._isFading = true;


            while (Fade.isFading) {

                fadeColor.a                = Mathf.Max(fadeColor.a - Time.deltaTime, 0f);
                Fade._instance._mask.color = fadeColor;

                yield return new WaitForEndOfFrame();

                Fade._instance._isFading = fadeColor.a > 0f;
                
            } // while ..
        } // IEnumerator ..


        /// <summary> A coroutine that fades the current screen to dark. </summary>
        public static IEnumerator FadeOut() {

            Color fadeColor = Fade.instance._mask.color;
            fadeColor.a              = 0f;
            Fade._instance._isFading = true;


            while (Fade.isFading) {

                fadeColor.a                = Mathf.Max(fadeColor.a + Time.deltaTime, 0f);
                Fade._instance._mask.color = fadeColor;
                
                yield return new WaitForEndOfFrame();

                Fade._instance._isFading = fadeColor.a < 1f;
                
            } // while ..
        } // IEnumerator ..
}} // namespace ..
