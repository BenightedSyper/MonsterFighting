using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAttack : Skill {
    public DoubleAttack(Monster _myself): base(_myself){
        skillettes = new Skillette[2];
        skillettes[0] = new Skillette(TARGET.SINGLE,new float[6]{0,3.7f,0,0,0,0}, null, null);
        skillettes[1] = new Skillette(TARGET.SINGLE,new float[6]{0,3.7f,0,0,0,0}, null, null);
    }
    public override void OnSkillStart(){
        //nothing
    }
    public override void OnSkillLand(){
        //nothing
    }
    public override void OnSkillEnd(SkilletteResponse _sr){
        //nothing
    }

    
}