using UnityEngine;

public class Goblin : Enemy {

    public Goblin(Transform i_tile) : base(i_tile) {
        speed = 2;
        hp = 2;
        damage = 1;
    }

    protected override void Update ( ) {
        base.Update( );
    }
}