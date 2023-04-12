using UnityEngine;


namespace Lumens {
/// <summary> Performs actions to a specified archetype. </summary>
public class System<ARCHETYPE> : MonoBehaviour {

    protected ARCHETYPE archetype;
    protected virtual void Awake() => this.archetype = this.GetComponent<ARCHETYPE>();
    
}} // namespace ..
