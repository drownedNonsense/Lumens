using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Lumens.Archetypes;

#if UNITY_EDITOR

namespace Lumens.Editors {
/// <summary> Handles higher planes. </summary>
[InitializeOnLoad]
public sealed class PlaneHandler {

    
    /*#########*/
    /* D A T A */
    /*#########*/

        private const int PLANE_MASK_OFFSET  = 4;
        private const int HIGHER_PLANE_ALPHA = 192;
        private static PlaneArchetype[] planes;
        private static Dictionary<int, int> planeEntitiesToHandle;


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        /// <summary> Add the plane handling function to the editor's loop. </summary>
        static PlaneHandler() {
            EditorApplication.update += PlaneHandler.Update;
            
            PlaneHandler.planes = GameObject.FindObjectsOfType<PlaneArchetype>();
            PlaneHandler.planeEntitiesToHandle = new Dictionary<int, int>(PlaneHandler.planes.Length);

            foreach (PlaneArchetype archetype in PlaneHandler.planes)
                PlaneHandler.planeEntitiesToHandle.Add(
                    archetype.gameObject.layer,
                    PlaneHandler.EntitiesToHandleCount(archetype.transform)
                ); // Add()
        } // void ..
 
    
        /// <summary> Perform the planes handling and changes entities color every time there is a change in the plane's child count. </summary>
        private static void Update() {
            if (!Application.isPlaying) {
                foreach (PlaneArchetype archetype in PlaneHandler.planes) {

                    if (archetype) {
                    
                        int entitiesToHandle = PlaneHandler.EntitiesToHandleCount(archetype.transform);
                        if (entitiesToHandle != PlaneHandler.planeEntitiesToHandle[archetype.gameObject.layer]) {

                            PlaneHandler.planeEntitiesToHandle[archetype.gameObject.layer] = entitiesToHandle;
                            foreach (Renderer renderer in archetype.GetComponentsInChildren<Renderer>())
                                renderer.sharedMaterial.color = ObjectColor(renderer.gameObject);

                        } // if ..
                    } // if ..
                } // foreach ..
            } // if ..
        } // void ..


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/
    
        /// <summary> Returns the colour the game object should have. </summary>
        private static Color32 ObjectColor(GameObject gameObject) {

            Color32 planeColor = Generic.PlaneColor(
                (Generic.PlaneLayer)(1 << Mathf.Max(
                    gameObject.layer - Generic.WHITE,
                    Generic.DEFAULT
            ))); // PlaneColor()

            if (gameObject.layer != Generic.WHITE)
                planeColor.a = PlaneHandler.HIGHER_PLANE_ALPHA;

            return planeColor;

        } // Color32 ..


        private static int EntitiesToHandleCount(Transform parent) {

            int count = 0;
            foreach (Transform child in parent) {
                count += PlaneHandler.EntitiesToHandleCount(child);
                if (child.gameObject.layer == Generic.DEFAULT) {

                    child.gameObject.layer = parent.gameObject.layer;
                    count++;
                } // if ..
            } // foreach ..


            return count;

        } // void ..
}} // namespace ..
#endif
