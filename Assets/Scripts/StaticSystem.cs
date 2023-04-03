using UnityEngine;


public class StaticSystem<ARCHETYPE> : MonoBehaviour where ARCHETYPE : Archetype {

    protected ARCHETYPE[] archetypes;
    protected virtual void Awake() => this.ReloadSystem();
    protected void ReloadSystem()  => this.archetypes = this.GetComponentsInChildren<ARCHETYPE>();
    
} // class ..
