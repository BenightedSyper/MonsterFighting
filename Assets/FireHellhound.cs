using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHellhound : Monster {
    public FireHellhound ():base( 1, 10, "Fire Hellhound", Type.Fire, Type.Fire, new int[]{1000,52,43,60,50,50}){
        skills[0] = new Bite(this);
    }
}