using UnityEngine;
using UnityEngine.InputSystem;


namespace Lumens.Singletons {
[RequireComponent(typeof(PlayerInput))]
/// <summary> A wrapper component for Unity's Input System. </summary>
public sealed class Controller : Singleton<Controller> {

    /*#########*/
    /* D A T A */
    /*#########*/

        public static Vector2 movement  => Controller.instance._movement;
        public static Vector2 selection => Controller.instance._selection;
        public static float   z         => Controller.instance._z;

        private Vector2 _movement;
        private Vector2 _selection;
        private float   _z;

        private InputAction _aAction;
        private InputAction _bAction;
        private InputAction _shiftAction;
        private InputAction _cancel;

        public static Button a      => new Button(Controller.instance._aAction);
        public static Button b      => new Button(Controller.instance._bAction);
        public static Button shift  => new Button(Controller.instance._shiftAction);
        public static Button cancel => new Button(Controller.instance._cancel);


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {

            base.Awake();

            PlayerInput playerInput = this.GetComponent<PlayerInput>();
            playerInput.actions = Resources.Load<InputActionAsset>("Controls");

            this._aAction     = playerInput.actions["A"];
            this._bAction     = playerInput.actions["B"];
            this._shiftAction = playerInput.actions["Shift"];
            this._cancel      = playerInput.actions["Cancel"];

        } // Awake()

        
    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        private void OnMovement(InputValue value) =>
            this._movement = value.Get<Vector2>();

        
        private void OnSelection(InputValue value) =>
            this._selection = value.Get<Vector2>();

            
        private void OnZ(InputValue value) =>
            this._z = value.Get<float>();


    public class Button {

        /// <summary> Is always true when the button is held down. </summary>
        public bool held = false;

        /// <summary> Is only true on the first frame the button is held down. </summary>
        public bool down = false;

        /// <summary> Is only true on the last frame the button is held down. </summary>
        public bool up   = false;
        

        public Button(InputAction action) {
            held = action.IsPressed();
            up   = action.WasReleasedThisFrame();
            down = action.WasPressedThisFrame() && action.IsPressed();
        } // Button ..

        public static implicit operator bool(Button x) =>
            x.held | x.up | x.down;

    } // class ..
}} // namespace ..
