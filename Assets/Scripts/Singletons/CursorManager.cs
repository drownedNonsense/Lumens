using UnityEngine;
using UnityEditor;


namespace Lumens.Singletons {
/// <summary> A static component that handles the game's cursor. </summary>
public sealed class CursorManager : Singleton<CursorManager> {

    /*#########*/
    /* D A T A */
    /*#########*/

        private Texture2D _defaultSprite;
        private Vector2   _defaultHotspot;
        
        private Texture2D _hoverSprite;
        private Vector2   _hoverHotspot;


        /// <summary> Is true when the cursor is hovering a specified entity. </summary>
        public static bool  isHovering => CursorManager.instance._isHovering;
        private       bool _isHovering = false;

        
    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        protected override void Awake() {

            base.Awake();

            CursorManager.instance._defaultSprite   = Resources.Load<Texture2D>("Sprites/cursor");
            CursorManager._instance._defaultHotspot = new Vector2(
                CursorManager._instance._defaultSprite.width  * 0.5f,
                CursorManager._instance._defaultSprite.height * 0.5f
            ); // Vector2()

            CursorManager.instance._hoverSprite   = Resources.Load<Texture2D>("Sprites/hoverCursor");
            CursorManager._instance._hoverHotspot = new Vector2(
                CursorManager._instance._hoverSprite.width  * 0.5f,
                CursorManager._instance._hoverSprite.height * 0.5f
            ); // Vector2()
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        /// <summary> Sets the cursor to its default or hovering state. </summary>
        public static void SetHover(bool isHovering) {

            CursorManager.instance._isHovering = isHovering;
            if (isHovering) Cursor.SetCursor(
                CursorManager._instance._hoverSprite,
                CursorManager._instance._hoverHotspot,
                CursorMode.Auto
            ); else Cursor.SetCursor(
                CursorManager._instance._defaultSprite,
                CursorManager._instance._defaultHotspot,
                CursorMode.Auto
            );
        } // void ..
}} // namespace ..
