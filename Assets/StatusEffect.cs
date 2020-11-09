using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATUSEFFECTTYPE { DEFENSEBREAK, ATTACKBREAK }

public class StatusEffect{
    public STATUSEFFECTTYPE statusType;
    public int duration;
    public float[] modifiers;
    public bool turnStart;
    public bool stacking;

    public StatusEffect(){
        this.statusType = STATUSEFFECTTYPE.DEFENSEBREAK;
        this.duration = 1;
        this.modifiers = new float[8]{1f,1f,1f,1f,1f,1f,1f,1f};
        this.turnStart = false;
        this.stacking = false;
    }
    public StatusEffect(STATUSEFFECTTYPE _type, int _duration, float[] _mods, bool _start = false, bool _stack = false){ 
        this.statusType = _type;
        this.duration = _duration;
        this.modifiers = _mods;
        this.turnStart = _start;
        this.stacking = _stack;
    }
    public StatusEffect(StatusEffect _se){
        this.statusType = _se.statusType;
        this.duration = _se.duration;
        this.modifiers = _se.modifiers;
        this.turnStart = _se.turnStart;
        this.stacking = _se.stacking;
    }
}