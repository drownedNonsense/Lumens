using UnityEngine;


namespace Lumens.Singletons {
    
[RequireComponent(typeof(AudioSource))]
/// <summary> Handles sound effects. </summary>
public sealed class SoundManager : Singleton<SoundManager> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private AudioSource _audioSource;
        private float _volume = 0.75f;
        private AudioClip _success;
        private AudioClip _failure;
        private AudioClip _click;
        private AudioClip _reflection;
        private AudioClip _power;
        private AudioClip _crunch;

        private const float VOLUME_SCALE = 0.2f;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {

            base.Awake();

            this._audioSource = this.GetComponent<AudioSource>();
            this._success     = Resources.Load<AudioClip>("Sounds/success");
            this._failure     = Resources.Load<AudioClip>("Sounds/failure");
            this._click       = Resources.Load<AudioClip>("Sounds/click");
            this._reflection  = Resources.Load<AudioClip>("Sounds/reflection");
            this._power       = Resources.Load<AudioClip>("Sounds/power");
            this._crunch      = Resources.Load<AudioClip>("Sounds/crunch");
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        private static void PlaySound(AudioClip audioClip, bool waitForEndOfClip) {
            if (!SoundManager.instance._audioSource.isPlaying || !waitForEndOfClip)
                SoundManager.instance._audioSource.PlayOneShot(
                    audioClip,
                    SoundManager._instance._volume * SoundManager.VOLUME_SCALE
                ); // PlayOneShot()
        } // void ..


        /// <summary> Set the game's sound effects volume. </summary>
        public static void SetVolume(float volume) =>
            SoundManager.instance._volume = volume;


        /// <summary> Plays a success sound effect. </summary>
        public static void PlaySuccess(bool waitForEndOfClip) =>
            SoundManager.PlaySound(SoundManager.instance._success, waitForEndOfClip);

        /// <summary> Plays a failure sound effect. </summary>
        public static void PlayFailure(bool waitForEndOfClip) =>
            SoundManager.PlaySound(SoundManager.instance._failure, waitForEndOfClip);

        /// <summary> Plays a click sound effect. </summary>
        public static void PlayClick(bool waitForEndOfClip) =>
            SoundManager.PlaySound(SoundManager.instance._click, waitForEndOfClip);

        /// <summary> Plays a reflection sound effect. </summary>
        public static void PlayReflection(bool waitForEndOfClip) =>
            SoundManager.PlaySound(SoundManager.instance._reflection, waitForEndOfClip);
            
        /// <summary> Plays the power sound effect. </summary>
        public static void PlayPower(bool waitForEndOfClip) =>
            SoundManager.PlaySound(SoundManager.instance._power, waitForEndOfClip);
            
        /// <summary> Plays a crunch sound effect. </summary>
        public static void PlayCrunch(bool waitForEndOfClip) =>
            SoundManager.PlaySound(SoundManager.instance._crunch, waitForEndOfClip);

}} // namespace ..
