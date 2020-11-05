using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TARGET { SINGLE, MULTI, RANDOM, SELF, ALLY, FRIENDLYTEAM } //"single" might need to be "selected"
public enum STAT { HEALTH, ATTACK, DEFENSE, SPATTACK, SPDEFENSE, SPEED }


public struct SkilletteResponse {
    public int damageDone;
    public Monster target;
    public Dictionary<string, dynamic> flags;
}

public struct d_P{
    public int duration;
    public float percent;

    public d_P(int _duration, float _percent){
         duration = _duration;
         percent = _percent;
    }
}

public struct Skillette {
    public TARGET target;
    public float[] damageScaling;
    public StatusEffect[] debuffs;
    public StatusEffect[] buffs;

   public Skillette(TARGET _target, float[] _dScale, StatusEffect[] _debuffs, StatusEffect[] _buffs){
        target = _target;
        damageScaling = _dScale;
        debuffs =  _debuffs;
        buffs = _buffs;
    }
}

public class Skill{
    public Skillette[] skillettes;
    internal Monster myMonster;
    
    public Skill(Monster _myself){
        myMonster = _myself;
        skillettes = new Skillette[1];
        skillettes[0] = new Skillette(TARGET.SINGLE,new float[6]{0,1,0,0,0,0}, null, null);
    }
    public Skill(Monster _myself, Skillette[] _sk){
        myMonster = _myself;
        skillettes = _sk;
    }

    public virtual void OnSkillStart (/*this should probably have some information about the current match*/){

    }

    public virtual void OnSkillLand (/*this happpens after the attack but doesnt need any other arguments*/){

    }

    public virtual void OnSkillEnd (SkilletteResponse _sr){

    }
    public void Respond (SkilletteResponse _sr){
        Debug.Log("i dealt " + _sr.damageDone + " damage to " + _sr.target.name);
    }
}