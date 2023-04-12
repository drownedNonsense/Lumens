using UnityEngine;


namespace Lumens {
/// <summary> Performs parallel actions to a specified array of archetypes. </summary>
public class StaticSystem<ARCHETYPE> : MonoBehaviour {

    protected ARCHETYPE[] archetypes;
    protected virtual void Awake() => this.ReloadSystem();


    /// <summary> Reloads at runtime all of its children's archetype. </summary>
    protected void ReloadSystem()  => this.archetypes = this.GetComponentsInChildren<ARCHETYPE>();
    
}} // namespace ..
