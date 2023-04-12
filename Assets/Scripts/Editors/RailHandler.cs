using UnityEngine;
using UnityEditor;
using Lumens.Archetypes;


namespace Lumens.Editors {
/// <summary> Handles path rails. </summary>
[InitializeOnLoad]
public sealed class RailHandler {

    /// <summary> Add the rails handling function to the editor's loop. </summary>
    static RailHandler() =>
         EditorApplication.update += RailHandler.Update;
 
    
    /// <summary> Perform the paths rails handling. </summary>
    private static void Update () {

        if (!Application.isPlaying)
            foreach (PathMovementArchetype archetype in GameObject.FindObjectsOfType<PathMovementArchetype>()) {

                if (archetype.data.nodes != null) {
                    if (archetype.data.nodes[0]) {
                        
                        archetype.transform.position = archetype.data.nodes[0].position;
                        archetype.transform.rotation = archetype.data.nodes[0].rotation;

                        archetype.renderer.positionCount = archetype.data.nodes.Length;
                        for (int nodeIndex = 0; nodeIndex < archetype.data.nodes.Length; nodeIndex++)
                            archetype.renderer.SetPosition(nodeIndex, archetype.data.nodes[nodeIndex].position);

                    } // if ..
                } // if ..
            } // foreach ..
     } // void ..
}} // namespace ..
