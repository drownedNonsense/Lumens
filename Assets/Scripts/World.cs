using System.Collections;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine;
using Lumens.Singletons;


namespace Lumens {
/// <summary> An abstract class for scenes. </summary>
public abstract class World : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/
        
        protected static ChromaticAberration chromaticAberration;
        private const float CHROMA_INTENSITY = 0.2f;
        private const float CHROMA_SPEED     = 2f;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected virtual void Awake() {

            MusicManager.PlayMusic();
            if (!SceneManager.GetSceneByName("Statics").isLoaded)
                SceneManager.LoadScene("Statics", LoadSceneMode.Additive);

            
            VolumeProfile profile = Resources.Load<VolumeProfile>("VolumeProfile");

            for (int i = 0; i < profile.components.Count; i++)
                if (profile.components[i].name == "ChromaticAberration")
                    World.chromaticAberration = (ChromaticAberration)profile.components[i];
                
        } // void ..


        protected virtual void Start() =>
            StartCoroutine(Fade.FadeIn());


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        /// <summary> Fades into a specified scene. </summary>
        protected void LoadWorld(string worldName) =>
            this.StartCoroutine(this.LoadWorldAsync(worldName));

        
        /// <summary> Fades from a menu to a specified menu. </summary>
        protected void LoadMenu(GameObject fromMenu, GameObject toMenu) =>
            this.StartCoroutine(this.LoadMenuAsync(fromMenu, toMenu));

        
        /// <summary> Closes the application. </summary>
        protected void QuitGame() =>
            this.StartCoroutine(this.QuitGameAsync());


        private IEnumerator LoadWorldAsync(string worldName) {

            this.StartCoroutine(Fade.FadeOut());
            while (Fade.isFading)
                yield return new WaitForEndOfFrame();

            SceneManager.LoadScene(worldName);

        } // IEnumerator ..


        private IEnumerator LoadMenuAsync(GameObject fromMenu, GameObject toMenu) {

            this.StartCoroutine(Fade.FadeOut());
            while (Fade.isFading)
                yield return new WaitForEndOfFrame();

            fromMenu.SetActive(false);
            toMenu.SetActive(true);
            this.StartCoroutine(Fade.FadeIn());
            while (Fade.isFading)
                yield return new WaitForEndOfFrame();

        } // IEnumerator ..


        private IEnumerator QuitGameAsync() {

            this.StartCoroutine(Fade.FadeOut());
            while (Fade.isFading)
                yield return new WaitForEndOfFrame();

            Application.Quit();

        } // IEnumerator ..


        
        /// <summary> A coroutine that applies a 'glitch' or shake effect to the camera. </summary>
        public static IEnumerator Shake() {

            float intensity = 1f;
            while (!float.IsNegative(intensity)) {

                World.chromaticAberration
                    .intensity
                    .value = World.CHROMA_INTENSITY
                    + (1f - World.CHROMA_INTENSITY) * intensity;
                intensity -= Time.deltaTime * World.CHROMA_SPEED;
                yield return new WaitForEndOfFrame();;

            } // for ..


            World.chromaticAberration.intensity.value = World.CHROMA_INTENSITY;
        } // void ..
}} // namespace ..
