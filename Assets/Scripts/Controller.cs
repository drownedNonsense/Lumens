using UnityEngine;
using UnityEngine.InputSystem;


public class Button {
    public bool held = false;
    public bool down = false;
    public bool up   = false;

    public Button(InputAction action) {
        held = action.IsPressed();
        up   = action.WasReleasedThisFrame();
        down = action.WasPressedThisFrame() && action.IsPressed();
    } // Button ..

    public static implicit operator bool(Button x) =>
        x.held | x.up | x.down;

} // struct ..


public class Controller : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        public Vector2 movement  { get; private set; }
        public Vector2 selection { get; private set; }
        public float   z         { get; private set; }

        private InputAction aAction;
        private InputAction bAction;
        private InputAction shiftAction;

        public Button a     => new Button(this.aAction);
        public Button b     => new Button(this.bAction);
        public Button shift => new Button(this.shiftAction);


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        void Awake() {

            PlayerInput playerInput = this.GetComponent<PlayerInput>();

            this.aAction     = playerInput.actions["A"];
            this.bAction     = playerInput.actions["B"];
            this.shiftAction = playerInput.actions["Shift"];

        } // Awake()

        
    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        private void OnMovement(InputValue value) =>
            this.movement = value.Get<Vector2>();

        
        private void OnSelection(InputValue value) =>
            this.selection = value.Get<Vector2>();

            
        private void OnZ(InputValue value) =>
            this.z = value.Get<float>();

} // class ..
