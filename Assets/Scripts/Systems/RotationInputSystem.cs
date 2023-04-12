using UnityEngine;
using Lumens.Singletons;
using Lumens.Archetypes;


namespace Lumens.Systems {
/// <summary> Handles player input into entity movement. </summary>
public sealed class RotationInputSystem : System<PlayerRotationArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() =>
            this.archetype.data.rotation = Mathf.Lerp(
                this.archetype.data.rotation,
                this.archetype.selectionData.isActive
                    ? Controller.z * 22.5f
                    : 0f,
                0.5f
            ); // Lerp()
}} // namespace ..
