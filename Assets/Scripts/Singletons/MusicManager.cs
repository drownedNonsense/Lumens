using UnityEngine;


namespace Lumens.Singletons {

[RequireComponent(typeof(AudioSource))]
/// <summary> Handles music. </summary>
public sealed class MusicManager : Singleton<MusicManager> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private AudioSource _audioSource;

        private const float VOLUME_SCALE = 0.5f;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {

            base.Awake();

            this._audioSource        = this.GetComponent<AudioSource>();
            this._audioSource.loop   = true;
            this._audioSource.clip   = Resources.Load<AudioClip>("Soundtrack");
            this._audioSource.volume = MusicManager.VOLUME_SCALE;

        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        /// <summary> Plays the game soundtrack. </summary>
        public static void PlayMusic() {
            if (!MusicManager.instance._audioSource.isPlaying)
                MusicManager._instance._audioSource.Play();
        } // void ..


        /// <summary> Set the game's music volume. </summary>
        public static void SetVolume(float volume) =>
            MusicManager.instance._audioSource.volume = volume * MusicManager.VOLUME_SCALE;


        /// <summary> Stops the game soundtrack. </summary>
        public static void StopMusic() =>
            MusicManager.instance._audioSource.Stop();

}} // namespace ..
