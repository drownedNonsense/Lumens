using UnityEngine;
using Lumens.Singletons;
using Lumens.Archetypes;


namespace Lumens.Systems {
/// <summary> Handles player translation input into entity movemet. </summary>
public sealed class TranslationInputSystem : System<PlayerTranslationArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() =>
            this.archetype.data.translation = Vector2.Lerp(
                this.archetype.data.translation,
                this.archetype.selectionData.isActive
                    ? Controller.movement
                    : Vector2.zero,
                0.5f
            ); // Lerp()
}} // namespace ..
