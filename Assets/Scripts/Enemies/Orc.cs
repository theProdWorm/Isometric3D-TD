using UnityEngine;

public class Orc : Enemy {
    public Orc ( ) {
        speed = 1;
        hp = 10;
        damage = 5;
    }

    protected override void Update ( ) {
        base.Update( );
    }
}
