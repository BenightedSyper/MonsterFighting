using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagabond : Monster{
    public Vagabond (): base(2,10, "Vagabond", Type.Fire, Type.Fire, new int[]{1000,10,60,50,50,25,10,10}){
        skills[0] = new SlashRocks(this);
        skills[1] = new SlashWaves(this);
    }
}