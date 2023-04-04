using UnityEngine;


/// <summary> An abstract class that works as a query of components, classes and structs for systems. </summary>
public abstract class Archetype : MonoBehaviour {

    /// <summary> An abstract function to initialise components and add systems. </summary>
    protected abstract void InitComponents();
    protected virtual  void Awake() => this.InitComponents();
    
} // class ..
