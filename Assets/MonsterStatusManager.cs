using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatusManager : MonoBehaviour
{
    public Monster myMonster;
    public Slider HealthBar;
    public Slider AttackBar;
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
}
