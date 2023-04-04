using UnityEngine;
using UnityEngine.Rendering.Universal;


/// <summary> Handles the plane archetypes. </summary>
public class PlaneSystem : StaticSystem<PlaneArchetype> {
    
    /*#########*/
    /* D A T A */
    /*#########*/

        private const int PLANE_MASK_OFFSET = 4;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Start() {
            foreach (PlaneArchetype plane in this.archetypes) {

                SetChildrenLayer(plane.transform);

                
                foreach (Renderer renderer in plane.renderers) renderer.material.color = ObjectColor(renderer.gameObject);
                foreach (Light2D light in plane.lights) light.color = ObjectColor(light.gameObject);

            } // foreach ..
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        /// <summary> Returns the colour the game object should have. </summary>
        private static Color32 ObjectColor(GameObject gameObject) {

            string[] tagArguments = gameObject.tag.Split(' ');
            Color32 planeColor    = Generic.PlaneColor(Mathf.Max(gameObject.layer - Generic.WHITE, Generic.DEFAULT));

            if (gameObject.layer != Generic.WHITE)
                planeColor.a = 192;

            if (tagArguments.Length > 1)
                planeColor = tagArguments[1] switch {
                    "Red"    => Generic.PlaneColor(Generic.PlaneLayer.Red),
                    "Yellow" => Generic.PlaneColor(Generic.PlaneLayer.Yellow),
                    "Blue"   => Generic.PlaneColor(Generic.PlaneLayer.Blue),
                    _        => planeColor,
                }; // switch ..

            return planeColor;

        } // Color32 ..


        /// <summary> Sets default children's default layer to the parent's layer. </summary>
        private static void SetChildrenLayer(Transform parent) {
            foreach (Transform child in parent) {

                if (child.gameObject.layer == Generic.DEFAULT)
                    child.gameObject.layer = parent.gameObject.layer;
                    
                SetChildrenLayer(child);

            } // foreach ..
        } // voiid ..
} // class ..
