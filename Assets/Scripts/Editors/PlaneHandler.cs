using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Lumens.Archetypes;


namespace Lumens.Editors {
/// <summary> Handles higher planes. </summary>
[InitializeOnLoad]
public sealed class PlaneHandler {

    
    /*#########*/
    /* D A T A */
    /*#########*/

        private const int PLANE_MASK_OFFSET  = 4;
        private const int HIGHER_PLANE_ALPHA = 192;
        private static Dictionary<PlaneArchetype, int> archetypes;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        /// <summary> Add the plane handling function to the editor's loop. </summary>
        static PlaneHandler() =>
            EditorApplication.update += PlaneHandler.Update;
 
    
        /// <summary> Perform the planes handling and changes entities color every time there is a change in the plane's child count. </summary>
        private static void Update() {
            if (!Application.isPlaying) {
                if (PlaneHandler.archetypes == null) {

                    PlaneArchetype[] archetypes = GameObject.FindObjectsOfType<PlaneArchetype>();
                    PlaneHandler.archetypes = new Dictionary<PlaneArchetype, int>(archetypes.Length);
                    foreach (PlaneArchetype archetype in archetypes)
                        PlaneHandler.archetypes.Add(archetype, archetype.transform.childCount);

                } // if ..

                foreach (KeyValuePair<PlaneArchetype, int> entry in PlaneHandler.archetypes) {
                        
                    SetChildrenLayer(entry.Key.transform);

                    int childCount = entry.Key.transform.childCount;
                    if (childCount != entry.Value) {

                        PlaneHandler.archetypes[entry.Key] = childCount;
                        foreach (Renderer renderer in entry.Key.GetComponentsInChildren<Renderer>())
                            renderer.sharedMaterial.color = ObjectColor(renderer.gameObject);

                    } // if ..
                } // foreach ..
            } // if ..
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        /// <summary> Returns the colour the game object should have. </summary>
        private static Color32 ObjectColor(GameObject gameObject) {

            string[] tagArguments = gameObject.tag.Split(' ');
            Color32 planeColor    = Generic.PlaneColor(Mathf.Max(
                gameObject.layer - Generic.WHITE,
                Generic.DEFAULT
            )); // PlaneColor()

            if (gameObject.layer != Generic.WHITE)
                planeColor.a = PlaneHandler.HIGHER_PLANE_ALPHA;

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
}} // namespace ..
