using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHellhound : Monster {
    public FireHellhound ():base( 1, 10, "Fire Hellhound", Type.Fire, Type.Fire, new Stats(39,52,43,60,50,65)){
        skill1 = new Bite(this);
    }
}