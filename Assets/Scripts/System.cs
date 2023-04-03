using UnityEngine;


public class System<ARCHETYPE> : MonoBehaviour where ARCHETYPE : Archetype {

    protected ARCHETYPE archetype;
    protected virtual void Awake() => this.archetype = this.GetComponent<ARCHETYPE>();
    
} // class ..
