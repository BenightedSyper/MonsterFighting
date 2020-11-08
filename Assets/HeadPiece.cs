using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPiece : Gear{

    public HeadPiece(){
        mySlot = SLOT.HEAD;
        level = 1;
        starLevel = 1;
        rarity = RARITY.GRAY;
        modifiers = new SVP[6]{new SVP (StatBooster.HPFLAT,1), null, null, null, null, null};
    }

    public HeadPiece(int starLevel, RARITY rarity){
        if (starLevel <= 6 && starLevel > 0){
            int temp = (starLevel * 50) + 25;
            modifiers[0] = new SVP (StatBooster.HPFLAT, temp);
        } 

        int rarityHolder = (int)rarity;
        while (rarityHolder > 0){
            //add modifier slots needs to be rabdom
            
            rarityHolder--;
        }
    }
}