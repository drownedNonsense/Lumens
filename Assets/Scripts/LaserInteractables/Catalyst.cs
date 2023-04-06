using UnityEngine;


public class Catalyst : LaserInteractable {
    
    /*#########*/
    /* D A T A */
    /*#########*/

        [field: SerializeField]
        public Generic.PlaneLayer planeLayer { get; private set; }
        public CatalystArchetype  archetype  { get; private set; }


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Awake() =>
            this.archetype = this.GetComponent<CatalystArchetype>();


    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        public override void OnPoweredStart(LaserArchetype laser, RaycastHit2D hit) {

            this.archetype.powerData.isPowered = true;
            if (!this.archetype.powerData.isActivated)
                this.archetype.TurnOn();


            if (laser.data.power > 1) {

                Vector2 outerSide = hit.collider.ClosestPoint(hit.centroid + (Vector2)laser.transform.up);
                Vector2 origin    = outerSide
                    + (outerSide -(Vector2)hit.transform.position).normalized * 0.001f;

                laser.data.reflection = LaserArchetype.NewInstance(
                    origin,
                    laser.transform.up,
                    laser.data.power - 1,
                    (Generic.PlaneLayer)(
                        (int)laser.data.planeLayer
                        ^ ((int)this.planeLayer & ~1))
                ); // NewInstance()
            } // if ..
        } // void ..


        public override void OnPowered(LaserArchetype laser, RaycastHit2D hit) {

            this.archetype.powerData.isPowered = true;

            if (laser.data.power > 1) {

                Vector2 outerSide = hit.collider.ClosestPoint(hit.centroid + (Vector2)laser.transform.up);
                Vector2 origin    = outerSide
                    + (outerSide -(Vector2)hit.transform.position).normalized * 0.001f;

                laser.data.reflection.transform.position = origin;
                laser.data.reflection.transform.up       = laser.transform.up;

            } // if ..
        } // void ..
} // class ..
