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
        [field: SerializeField] private TextMeshProUGUI _timeLeftInfo;
        [field: SerializeField] private int _timeLimit;

        private static bool levelPaused = false;

        /// <summary> A static reference to the current laser power strength. </summary>
        public static int power => 1 << Level.litCatalystCount + Level.DEFAULT_POWER;

        private static GameObject timeLeftInfo;
        private static GameObject infoBoxes;
        private static TextMeshProUGUI goal;
        private static GameObject levelCompletedMenu;
        private static TextMeshProUGUI levelCompleted;

        /// <summary> A static counter of lit catalysts. </summary>
        private static int litCatalystCount = 0;

        /// <summary> A static counter of catalyst on level loading. </summary>
        private static int catalystCount = 0;

        /// <summary> A static counter of remaining time on this level. </summary>
        private static float timeLeft = 0;


        private const int DEFAULT_POWER       = 2;
        private const int CATALYST_TIME_BONUS = 15;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Start() {
            base.Start();

            Time.timeScale = 1f;

            Level.catalystCount      = GameObject.FindObjectsOfType<CatalystArchetype>().Length;
            Level.timeLeftInfo       = this._timeLeftInfo.gameObject;
            Level.infoBoxes          = this._infoBoxes;
            Level.goal               = this._goal;
            Level.levelCompletedMenu = this._levelCompletedMenu;
            Level.levelCompleted     = this._levelCompleted;
            Level.UpdateGoalText();

            Level.timeLeft = this._timeLimit;
        } // void ..


        private void Update() {
            if (!Level.levelPaused) {

                Level.timeLeft -= Time.deltaTime;
                
                this._timeLeftInfo.text = ((int)Level.timeLeft).ToString();
                this._infoBoxes.SetActive(this._infoBoxes.activeSelf ^ Controller.cancel.up);

                if (float.IsNegative(Level.timeLeft))
                    Level.LevelFailed();

            } // if ..
        } // void ..


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
            Level.TimeBonus();

            if (Level.litCatalystCount >= Level.catalystCount)
                Level.LevelCompleted();

        } // void ..


        /// <summary> Increases the remaining time counter. </summary>
        private static void TimeBonus() =>
            Level.timeLeft += Level.CATALYST_TIME_BONUS;


        /// <summary> Performs the level completion logics. </summary>
        public static void LevelCompleted() {

            Level.levelPaused = true;
            Level.timeLeftInfo.SetActive(false);
            Level.infoBoxes.SetActive(false);
            Level.levelCompletedMenu.SetActive(true);
            Level.levelCompleted.text =
                $"LEVEL COMPLETED\n***\nYou have brought back the light\nin the {SceneManager.GetActiveScene().name}!";

        } // void ..


        /// <summary> Performs the level failure logics. </summary>
        public static void LevelFailed() {

            Level.levelPaused = true;
            SoundManager.PlayFailure(false);
            Level.timeLeftInfo.SetActive(false);
            Level.infoBoxes.SetActive(false);
            Level.levelCompletedMenu.SetActive(true);
            Level.levelCompleted.text =
                $"LEVEL FAILED\n***\nYou did not manage to bring\nthe light back to the {SceneManager.GetActiveScene().name}...";

        } // void ..


        /// <summary> Brings the player back to the menu. </summary>
        public void OnBackToMenu() {
            base.LoadWorld("Menu");
        } // void ..
}} // namespace ..
