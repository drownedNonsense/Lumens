using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lumens.Singletons;


namespace Lumens {
/// <summary> An abstract class for scenes. </summary>
public abstract class World : MonoBehaviour {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected virtual void Start() =>
            StartCoroutine(Fade.FadeIn());


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/


        /// <summary> Fades into a specified scene. </summary>
        protected void LoadWorld(string worldName) =>
            this.StartCoroutine(this.LoadWorldAsync(worldName));

        
        /// <summary> Closes the application. </summary>
        protected void QuitGame() =>
            this.StartCoroutine(this.QuitGameAsync());


        private IEnumerator LoadWorldAsync(string worldName) {

            this.StartCoroutine(Fade.FadeOut());
            while (Fade.isFading)
                yield return new WaitForEndOfFrame();

            SceneManager.LoadScene(worldName);

        } // IEnumerator ..


        private IEnumerator QuitGameAsync() {

            this.StartCoroutine(Fade.FadeOut());
            while (Fade.isFading)
                yield return new WaitForEndOfFrame();

            Application.Quit();

        } // IEnumerator ..
}} // namespace ..
