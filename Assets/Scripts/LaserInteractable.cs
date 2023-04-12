using UnityEngine;
using Lumens.Archetypes;


namespace Lumens {
/// <summary> Performs actions when the entity is hit by a laser. </summary>
public abstract class LaserInteractable : MonoBehaviour {

    /// <summary> Performs an action on the frame the entity is hit. </summary>
    public abstract void OnPoweredStart(LaserArchetype laser, RaycastHit2D hit);

    /// <summary> Performs an action when the entity is hit. </summary>
    public abstract void OnPowered(LaserArchetype laser, RaycastHit2D hit);

}} // namespace ..
