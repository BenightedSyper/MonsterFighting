using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : Skill {
    public Bite(Monster _myself): base(_myself){
        skillettes = new Skillette[1];
        skillettes[0] = new Skillette(TARGET.SINGLE,new float[6]{0,3.6f,0,0,0,0}, null);
    }
    public override void OnSkillStart(){
        //nothing
    }
    public override void OnSkillLand(){

    }
    public override void OnSkillEnd(SkilletteResponse _sr){
        //gain 30% life from damage done
        //dynamic dam;
        //_sr.flags.TryGetValue("damageDealt", out dam);
        //monster gain 30% of dam
        int gain = (int) Math.Floor(_sr.damageDone * 0.3);
        myMonster.gainHealth(gain);
        Debug.Log($"{myMonster.name} gains {gain} from Bite");
    }
    public override void OnSkillEnd2(dynamic _var){
        //int test = _var.flags["damageDealt"];
    }
}