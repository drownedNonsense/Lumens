using UnityEngine;


namespace Lumens {
[ExecuteInEditMode]
/// <summary> An abstract class that works as a query of components, classes and structs for systems. </summary>
public abstract class Archetype<ARCHETYPE> : MonoBehaviour {

    /// <summary> A reference to the archetype's system. </summary>
    protected System<ARCHETYPE> system;

    /// <summary> An abstract function to initialise components and add systems. </summary>
    protected abstract void InitComponents();
    protected virtual void Awake() => this.InitComponents();
    
}} // namespace ..
