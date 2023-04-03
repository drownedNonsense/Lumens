using UnityEngine;


public abstract class Archetype : MonoBehaviour {

    protected abstract void LoadComponents();
    protected virtual  void Awake() => this.LoadComponents();
    
} // class ..
