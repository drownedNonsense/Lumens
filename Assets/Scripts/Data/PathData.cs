using UnityEngine;


namespace Lumens.Data {
public class PathData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/
    
        /// <summary> An array of nodes that are part of a path. </summary>
        public Transform[] nodes = null;

        /// <summary> Makes the entity loop through all of its node until false. </summary>
        public bool loop = true;

        /// <summary> Makes the entity move from the lowest to the highest indexed node. </summary>
        public bool movesForward = true;

        /// <summary> Points at the index of the current node path. </summary>
        public int currentNodeIndex = 0;

        /// <summary> Points at the next path node if it exists. </summary>
        public Transform nextNode { get {
            if (this.nodes != null)
                if (this.movesForward) return this.nodes[this.currentNodeIndex + 1];
                else                   return this.nodes[this.currentNodeIndex - 1];
            else return this.transform;
        }} // Transform ..

        /// <summary> Is true when the entity has reached the last path node. </summary>
        public bool isAtTheEnd =>
              (this.currentNodeIndex == this.nodes.Length - 1 &&  this.movesForward)
            | (this.currentNodeIndex == 0                     && !this.movesForward);

        /// <summary> Is true when the entity is at the next path node position. </summary>
        public bool hasReachedTheNextNode =>
            (this.nextNode.position - this.transform.position)
                .sqrMagnitude < 0.005f;

}} // namespace ..
