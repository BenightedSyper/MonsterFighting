using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashWaves : Skill {
    public SlashWaves(Monster _myself): base(_myself){
        skillettes = new Skillette[2];
        skillettes[0] = new Skillette(TARGET.SINGLE,
                                new float[8]{0.12f,1f,0f,0f,0f,0f,0f,0f},
                                new StatusEffect[1]{new StatusEffect(STATUSEFFECTTYPE.ATTACKBREAK,2,
                                            new float[8]{1f,0.7f,1f,1f,1f,1f,1f,1f})}, null);
        skillettes[1] = new Skillette(TARGET.SINGLE,
                                new float[8]{0.12f,1f,0f,0f,0f,0f,0f,0f},
                                new StatusEffect[1]{new StatusEffect(STATUSEFFECTTYPE.ATTACKBREAK,2,
                                            new float[8]{1f,0.7f,1f,1f,1f,1f,1f,1f})}, null);
    }
    public override void OnSkillStart(){
        
    }
    public override void OnSkillLand(){

    }
    public override void OnSkillEnd(SkilletteResponse _sr){

    }
}