using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatusManager : MonoBehaviour
{
    public Monster myMonster;
    public Slider HealthBar;
    public Slider AttackBar;
    public Texture defenseBreak;
    public Texture attackBreak;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if(myMonster == null){
            return;
        }
        HealthBar.value = myMonster.GetPercentHealth();
        AttackBar.value = myMonster.GetPercentAttackBar();
    }
    void OnGUI(){
        foreach (StatusEffect se in myMonster.statusEffects){
            switch (se.statusType){
                case STATUSEFFECTTYPE.DEFENSEBREAK:
                    Graphics.DrawTexture(new Rect(10, 10, 100, 100), defenseBreak);
                    break;
                case STATUSEFFECTTYPE.ATTACKBREAK:
                    Graphics.DrawTexture(new Rect(110, 10, 100, 100), attackBreak);
                    break;
                default:
                    break;
            }
        }
    }
}
