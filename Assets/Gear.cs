using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SLOT {HEAD, SHIRT, PANTS, BOOTS, LHAND, RHAND}
public enum RARITY {GRAY, GREEN ,BLUE ,PURPLE ,ORANGE}

public enum StatBooster { HPFLAT, HPPERCENT, 
                          ATTACKFLAT, ATTACKPERCENT, 
                          DEFFLAT, DEFPERCENT, 
                          MAJFLAT, MAJPERCENT, 
                          MAJDEFFLAT, MAJDEFPERCENT,                     
                          SPEED, ACC, RES }

public class SVP{
    public StatBooster stat;
    public int value;
    public SVP(StatBooster _s, int _v){
        this.stat = _s;
        this.value = _v;
    }
}

public class Gear{

    //Basic parts that eevery Ruin no matter what will have to consider.
    public int level;
    public int starLevel;
    public RARITY rarity;
    public SLOT mySlot;
    public SVP[] modifiers;
    public SVP mainStat{
        get{
            return modifiers[0];        //this is the base stat
        }
    } 
    public SVP inateStat{
        get{
            return modifiers[1];        //this will be the inate
        }
    }
    public SVP subStatOne{
        get{
            return modifiers[2];        //substat one
        }
    }
    public SVP subStatTwo{
        get{
            return modifiers[3];        //substat two
        }
    }
    public SVP subStatThree{
        get{
            return modifiers[4];        //substat three
        }
    }
    public SVP subStatFour{
        get{
            return modifiers[5];        //substat four
        }
    }  

    //This is the worst case scenario. If everything goes wrond this piece of gear would be called.
    public Gear(){
        level = 1;
        starLevel = 1;
        mySlot = SLOT.HEAD;
        rarity = RARITY.GRAY;
        modifiers = new SVP[6]{new SVP (StatBooster.HPFLAT,1), null, null, null, null, null};
    }

    public Gear(int _level, int _star, SLOT _slot, SVP[] _mods){
        this.level = _level;
        this.starLevel = _star;
        this.mySlot = _slot;
        this.modifiers = _mods;
    }

    public void AddSubStat(){

    }

}