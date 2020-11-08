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
                          SPEDD, ACC, RES }

public class SVP{
    StatBooster stat;
    int value;
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

/*thinking our loud ---- Inate is going to be tricky because it will possably be alot of wierd stuff

    //This would be a 1 star helmet
    public Gear(int level,int starLevel, Slot mySlot, SVP mainStat, SVP inate, SVP subSlotone, SVP subSlottwo, SVP subSlotthree, SVP subSlotfour){
        this.level = 1;
        this.starLevel = 1;
        this.mySlot = Slot.HEAD;
        this.mainStat = new SVP(StatBooster.HPFLAT, 10);
        this.inate = //some how call a random value inate will need its own enum or dictionary
        this.subSlotone = null;
        this.subSlottwo = null;
        this.subSlotthree = null;
        this.subSlotfour = null;
    }

    //This would be a 2 star Helmet
    public Gear(int level,int starLevel, Slot mySlot, SVP mainStat, SVP Inate, SVP subSlotone, SVP subSlottwo, SVP subSlotthree, SVP subSlotfour){
        this.level = 1;
        this.starLevel = 2;
        this.mySlot = Slot.HEAD;
        this.mainStat = new SVP(StatBooster.HPFLAT, 20);
        this.inate = //some how call a random value inate will need its own enum or dictionary
        this.subSlotone = null;
        this.subSlottwo = null;
        this.subSlotthree = null;
        this.subSlotfour = null;
    }
    
    Gear headGear1 = new Gear(1, 1, Slot.HEAD, StatBooster.HPFLAT(Health,100), null, null, null, null, null )

*/

}