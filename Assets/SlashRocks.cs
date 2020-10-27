using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashRocks : Skill {
    public SlashRocks(Monster _myself): base(_myself){
        skillettes = new Skillette[1];
        skillettes[0] = new Skillette(
            TARGET.SINGLE,
            new double[6]{0.18,1,0,0,0,0}),
            new Dictionary<string, d_P>(){
                ["defenseBreak"] = new d_P(2,0.4)  
            };
    }
    public override void OnSkillStart(){
        
    }
    public override void OnSkillLand(){

    }
    public override void OnSkillEnd(){

    }
}