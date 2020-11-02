using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Slot {HEAD, SHIRT, PANTS, BOOTS, LHAND, RHAND}

public enum StatBooster { HPFLAT, HPPERCENT, ATTACKFLAT, ATTACKPERCENT, DEFFLAT, DEFPERCENT,MAJFLAT, MAJPERCENT, SPEDD, ACC, RES }

public struct SVP{
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
    public SVP mainStat; 
    public SVP Inate;
    public Slot mySlot;
    public SVP subSlotone;
    public SVP subSlottwo;
    public SVP subSlotthree;
    public SVP subSlotfour;    

    //This is the worst case scenario. If everything goes wrond this piece of gear would be called.
    public Gear(){
        level=1;
        mySlot=Slot.HEAD;   
        mainStat= new SVP (StatBooster.HPFLAT,1);
        //Inate= null;
        //subSlotone= null;
        //subSlottwo= null;
        //subSlotthree= null;
        //subSlotfour= null;
    }
/*thinking our loud

    public Gear(int level,int starLevel, Slot mySlot, SVP mainStat, SVP Inate, SVP subSlotone, SVP subSlottwo, SVP subSlotthree, SVP subSlotfour){
        this.level = 1;
        this.starLevel = 1;
    }
    
    Gear headGear1 = new Gear(1, 1, Slot.HEAD, StatBooster.HPFLAT(Health,100), null, null, null, null, null )

*/

}