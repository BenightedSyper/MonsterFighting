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
    public double percent;

    public d_P(int _duration, double _percent){
         duration = _duration;
         percent = _percent;
    }
}

public struct Skillette {
    public TARGET target;
    public double[] damageScaling;
    public Dictionary<string, d_P> debuffs;

   public Skillette(TARGET _target, double[] _dScale, Dictionary<string, double> debuffCalc){
        target = _target;
        damageScaling = _dScale;
        debuffs =  debuffCalc;
    }
}

public class Skill{
    public Skillette[] skillettes;
    internal Monster myMonster;
    
    public Skill(Monster _myself){
        myMonster = _myself;
        skillettes = new Skillette[1];
        skillettes[0] = new Skillette(TARGET.SINGLE,new double[6]{0,1,0,0,0,0});
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
    public virtual void OnSkillEnd2(dynamic _var){

    }

    public void Respond (SkilletteResponse _sr){
        Debug.Log("i dealt " + _sr.damageDone + " damage to " + _sr.target.name);
    }
}