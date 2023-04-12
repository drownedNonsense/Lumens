using Lumens.Archetypes;


namespace Lumens.Systems {
/// <summary> Handles the power source archetype. </summary>
public sealed class PowerSourceSystem : System<PowerSourceArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void LateUpdate() {
            foreach (PowerArchetype power in this.archetype.data.powerOutputs) {

                if (this.archetype.powerData.isPowered) power.data.isPowered |= true;
                else                                    power.data.isPowered |= false;

            } // foreach ..
        } // void ..
}} // namespace ..
