using Lumens.Archetypes;


namespace Lumens.Systems {
/// <summary> Handles the power source archetype. </summary>
public sealed class PowerSystem : System<PowerArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {

            this.archetype.data.isActivated =
                this.archetype.data.isPowered
                | (this.archetype.data.isActivated && this.archetype.data.remainActivated);

            this.archetype.data.isPowered = false;

        } // void ..
}} // namespace ..
