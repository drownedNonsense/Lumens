using UnityEngine;


/// <summary> Performs actions to a specified archetype. </summary>
public class System<ARCHETYPE> : MonoBehaviour where ARCHETYPE : Archetype {

    protected ARCHETYPE archetype;
    protected virtual void Awake() => this.archetype = this.GetComponent<ARCHETYPE>();
    
} // class ..
