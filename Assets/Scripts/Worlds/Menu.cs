using UnityEngine;
using Lumens.Singletons;


namespace Lumens {
public class Menu : World {    

    /*#########*/
    /* D A T A */
    /*#########*/

        [field: SerializeField] private GameObject mainMenu;
        [field: SerializeField] private GameObject settingsMenu;


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
        
        /// <summary> Loads the tutorial level. </summary>
        public void OnNewGame() =>
            base.LoadWorld("Tutorial");


        /// <summary> Closes the game. </summary>
        public void OnQuit() =>
            base.QuitGame();


        /// <summary> Load the setting menu. </summary>
        public void OnSettingsMenu() =>
            base.LoadMenu(this.mainMenu, this.settingsMenu);

        
        /// <summary> Load the main menu. </summary>
        public void OnMainMenu() =>
            base.LoadMenu(this.settingsMenu, this.mainMenu);

        
        /// <summary> Changes the game's music volume. </summary>
        public void OnMusicVolumeChange(float volume) =>
            MusicManager.SetVolume(volume);


        /// <summary> Changes the game's effects volume. </summary>
        public void OnEffectsVolumeChange(float volume) =>
            SoundManager.SetVolume(volume);

}} // namespace ..
