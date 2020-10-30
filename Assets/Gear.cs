using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Slot {Head, Shirt, Pants, Boots, LHand, RHand}

public enum StatBooster { HPFLAT, HPPERCENT, ATTACKFLAT, ATTACKPERCENT }

public struct SVP{
    StatBooster stat;
    int value;
    public SVP(StatBooster _s, int _v){
        this.stat = _s;
        this.value = _v;
    }
}

public class Gear{

    public int level;
    public SVP mainStat; 
    public SVP Inate;
    public Slot mySlot;
    public SVP subSlotone;
    public SVP subSlottwo;
    public SVP subSlotthree;
    public SVP subSlotfour;    

    public Gear(){
        level=1;
        mySlot=Slot.Head;   
        mainStat= new SVP (StatBooster.HPFLAT,1);
    }
}