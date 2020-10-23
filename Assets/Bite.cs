using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : Skill {
    public Bite(Monster _myself): base(_myself){
        skillettes = new Skillette[1];
        skillettes[0] = new Skillette(TARGET.SINGLE,new double[6]{0,3.6,0,0,0,0});
    }
    public override void OnSkillStart(){
        //nothing
    }
    public override void OnSkillEnd (SkilletteResponse _sr){
        //gain 30% life from damage done
        dynamic dam;
        _sr.flags.TryGetValue("damageDealt", out dam);
        //monster gain 30% of dam
        //int gain = Math.Floor(dam * 0.3f);
        //myMonster.gainHealth(gain);
    }
    public override void OnSkillEnd2(dynamic _var){
        //int test = _var.flags["damageDealt"];
    }
}