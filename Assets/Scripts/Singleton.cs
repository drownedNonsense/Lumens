using UnityEngine;


namespace Lumens {
/// <summary> Implements a static instance while enforcing its runtime safety. </summary>
public class Singleton<COMPONENT> : MonoBehaviour where COMPONENT : Component {

    /*#########*/
    /* D A T A */
    /*#########*/
        
        protected static COMPONENT _instance;

        /// <summary> A reference to the current instance of the singleton. </summary>
        public static COMPONENT  instance {
            get {

                if (!Singleton<COMPONENT>._instance) {

                    Singleton<COMPONENT>._instance = GameObject.FindObjectOfType<COMPONENT>();
                    if (!Singleton<COMPONENT>._instance) {

                        GameObject statics = new GameObject("Statics");
                        statics.tag = "Statics";
                        Singleton<COMPONENT>._instance = statics.AddComponent<COMPONENT>();

                    } // if ..
                } // if ..


                return Singleton<COMPONENT>._instance;

            } // get ..
        } // COMPONENT ..

 
    /*###################*/
    /* L I F E   T I M E */
    /*###################*/
        
        protected virtual void Awake () {

            DontDestroyOnLoad(this.gameObject);

            
            if (!Singleton<COMPONENT>._instance) {

                Singleton<COMPONENT>._instance = this as COMPONENT;
                DontDestroyOnLoad(this.gameObject);

            } else Destroy (gameObject);
        } // void ..
}} // namespace ..
