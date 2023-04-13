using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Lumens.Singletons;
using Lumens.Archetypes;


namespace Lumens {
public class Level : World {    

    /*#########*/
    /* D A T A */
    /*#########*/

        [field: SerializeField] private GameObject _infoBoxes;
        [field: SerializeField] private TextMeshProUGUI _goal;
        [field: SerializeField] private GameObject _levelCompletedMenu;
        [field: SerializeField] private TextMeshProUGUI _levelCompleted;

        /// <summary> A static reference to the current laser power strength. </summary>
        public static int power => 1 << Level.litCatalystCount + Level.DEFAULT_POWER;

        private static GameObject infoBoxes;
        private static TextMeshProUGUI goal;
        private static GameObject levelCompletedMenu;
        private static TextMeshProUGUI levelCompleted;

        /// <summary> A static counter of lit catalysts. </summary>
        private static int litCatalystCount = 0;

        /// <summary> A static counter of catalyst on level loading. </summary>
        private static int catalystCount    = 0;


        private const int DEFAULT_POWER = 2;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Start() {
            base.Start();
            Level.litCatalystCount = 0;
            Level.catalystCount    = GameObject.FindObjectsOfType<CatalystArchetype>().Length;
            Level.infoBoxes          = this._infoBoxes;
            Level.goal               = this._goal;
            Level.levelCompletedMenu = this._levelCompletedMenu;
            Level.levelCompleted     = this._levelCompleted;
            Level.UpdateGoalText();
        } // void ..


        private void Update() =>
            this._infoBoxes.SetActive(this._infoBoxes.activeSelf ^ Controller.cancel.up);


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        /// <summary> Updates the goal info box. </summary>
        private static void UpdateGoalText() =>
            Level.goal.text = $"{Level.litCatalystCount}/{Level.catalystCount} catalyst(s) lit";


        /// <summary> Increases the lit catalyst counter while checking if the level is completed. </summary>
        public static void IncreaseCatalystCount() {

            Level.litCatalystCount++;
            Level.UpdateGoalText();

            if (Level.litCatalystCount >= Level.catalystCount)
                Level.LevelCompleted();

        } // void ..


        /// <summary> Performs the level completion logics. </summary>
        public static void LevelCompleted() {

            Level.infoBoxes.SetActive(false);
            Level.levelCompletedMenu.SetActive(true);
            Level.levelCompleted.text =
                $"LEVEL COMPLETED\n***\nYou have brought back the light\nin the {SceneManager.GetActiveScene().name}!";

        } // void ..


        /// <summary> Brings the player back to the menu. </summary>
        public void OnBackToMenu() =>
            base.LoadWorld("Menu");

}} // namespace ..
