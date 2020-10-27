using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagabond : Monster{
    public Vagabond (): base(2,10, "Vagabond", Type.Fire, Type.Fire, new Stats(100,10,60,50,50,50)){
        skill1 = new SlashRocks(this);
    }
}