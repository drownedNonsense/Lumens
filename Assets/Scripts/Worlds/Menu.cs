namespace Lumens {
public class Menu : World {    

    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
        
        /// <summary> Loads the tutorial level. </summary>
        public void OnNewGame() =>
            base.LoadWorld("Tutorial");


        /// <summary> Closes the game. </summary>
        public void OnQuit() =>
            base.QuitGame();

}} // namespace ..
