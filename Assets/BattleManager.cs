using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rand = UnityEngine.Random;
using UnityEditor;

public struct SkillInfo {
    public int[] targets;
    public Monster[] targetMonsters;
}
public struct SkillResult {

}
//delegate SkillResult skillChoice (SkillInfo _i);

public class BattleManager : MonoBehaviour
{
    public const double SPEEDPERCENT = 0.1;
    public Monster monOne; //probably need an array of player monster/team
    public Monster monTwo; //an array for the other team, maybe multi dimentional for scenerios 
    public Monster hell;
    public Monster vaga;

    public Monster[] team;
    public Monster[] friendlyMonsters;
    public Monster[] enemyMonsters;

    public enum GAMESTATE { PLAYERTURN, ENEMYTURN, TICKING, PAUSE, RUNNING }
    public GAMESTATE myState;

    public Texture2D emptyProgressBar;
    public Texture2D fullProgressBar;

    public GameObject prefabMSM;
    public GameObject hellhoundGO;
    public GameObject vagaGO;

    public Transform friendlySpawn1, friendlySpawn2, friendlySpawn3, friendlySpawn4;
    public Transform enemySpawn1, enemySpawn2, enemySpawn3, enemySpawn4;

    public GameObject battleText;

    private int selectedSkill = 0;

    //private skillChoice chosenSkill = null;

    private int tick;
    // Start is called before the first frame update
    void Start()
    {
        myState = GAMESTATE.PAUSE;
        //create two monsters
        //monOne = new Monster(0, 10, "Bulbasaur", Type.Grass, Type.Grass, new int[]{45,49,49,65,65,45});
        //monTwo = new Monster(1, 10, "Charmander", Type.Fire, Type.Fire, new int[]{39,52,43,60,50,65});

        Gear gear = new HeadPiece();

        hell = new FireHellhound();
        hell.SetPlayerID(0);
        hellhoundGO = Instantiate(prefabMSM, enemySpawn1.position, Quaternion.identity);
        MonsterStatusManager myMSM = hellhoundGO.GetComponent<MonsterStatusManager>();
        myMSM.myMonster = hell;
        

        vaga = new Vagabond();
        vaga.SetPlayerID(1);
        vagaGO = Instantiate(prefabMSM, friendlySpawn1.position ,Quaternion.identity);
        MonsterStatusManager vagaMSM = vagaGO.GetComponent<MonsterStatusManager>();
        vagaMSM.myMonster = vaga;
        vaga.equipment[0] = gear;

        friendlyMonsters = new Monster[1]{ vaga };
        enemyMonsters = new Monster[1]{ hell };

        //test.Print();

        team = new Monster[2]{ hell, vaga };
        
        //monOne.Print();
        //monTwo.Print();
        //friendlyTeam = new BattleData[1]{new BattleData(0)};
        //enemyTeam = new BattleData[1]{new BattleData(1)};
        //set defaults

        //test combat
        InitilizeCombatSW();
    }

    // Update is called once per frame
    void Update()
    {
        switch(myState){
            case GAMESTATE.TICKING: 
                UpdateCombatSW();
                break;
            case GAMESTATE.PLAYERTURN:
                //player selects option
                //playerTurnChoice();
                break;
            case GAMESTATE.RUNNING:
            default:
                break;
        }
        

        //check for user input
        //based on game state
        //player turn

    }
    void OnGUI(){
        /*
        double per = hell.attackBar.bar /100;
        //Debug.Log(per);
        per *= Screen.width;
        GUI.DrawTexture(new Rect(0, 70, Screen.width, 50), emptyProgressBar);
        GUI.DrawTexture(new Rect(0, 80, (float)per, 30), fullProgressBar);
        */
        switch (myState)
        {
            case GAMESTATE.PLAYERTURN:
                //team[0]'s skill sprites for the buttons
                if (GUI.Button(new Rect(10, 10, 50, 50), "Skill 1" )){
                    selectedSkill = 1;
                    //PlayerTurnChoice(1);
                }
                if (GUI.Button(new Rect(70, 10, 50, 50), "Skill 2" )){
                    selectedSkill = 2;
                    //PlayerTurnChoice(2);
                }
                if ( Input.GetMouseButtonDown (0)){ 
                    RaycastHit hit; 
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
                    if ( Physics.Raycast (ray,out hit,100.0f)) {
                        if(hit.transform.tag == "Enemy"){
                            Monster targetMonster = hit.transform.GetComponent<MonsterStatusManager>().myMonster;
                            PlayerTurnChoice(team[0], selectedSkill, targetMonster, hit.transform);
                        }
                        //Monster targetMonster = hit.transform.GetComponent<MonsterStatusManager>().myMonster;
                        //PlayerTurnChoice();
                        //Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    }
                }
                break;
            default:
                break;
        }
        
    }
    public void EnemyTurnChoice(Monster _mon){
        if(myState != GAMESTATE.ENEMYTURN){
            return;
        }
        //select a skill and a target for the enemy monster to use
        _mon.attackBar.Zero();
        _mon.OnTurnEnd();
        myState = GAMESTATE.TICKING;
    }
    public void PlayerTurnChoice(Monster _curr, int _skill, Monster _target, Transform _targetTransform){
        if(myState != GAMESTATE.PLAYERTURN){
            return;
        }

        Skill chosen = _curr.skills[_skill - 1];
        foreach(Skillette _s in chosen.skillettes){
            int totalDamage = 0;
            for(int i = 0; i < 8; i++){
                totalDamage += (int) (_curr.matchStats[i] * _s.damageScaling[i]);
            }
            //check for critical strike
            //roll for debuff
            int damageDone = _target.takeDamage(totalDamage); //probably should make an attack object with damage and damage type and other things
            SkilletteResponse response = new SkilletteResponse();
            response.damageDone = damageDone;
            GameObject bText = Instantiate(battleText, _targetTransform.position, Quaternion.identity);
            bText.transform.GetChild(0).GetComponent<TextMesh>().text = damageDone.ToString();
            //add flags for debuffs landed or other events like KO'ing a monster
            foreach (StatusEffect debuff in _s.debuffs){
                float chance = 0f;
                chance = (float)_curr.currentAccuracy / ((float)_curr.currentAccuracy + (float)_target.currentResistance);
                //Debug.Log($"my chance to land a Debuff is {chance}");    
                if(Rand.value < chance){
                    //debuff name
                    //debuff type
                    //debuff duration
                    //count on turn start/end
                    SkilletteResponse SER = _target.takeStatus(new StatusEffect(debuff));
                }
            }
            //merge dictionary of effects that happened this skillette
            chosen.OnSkillEnd(response);
            
        }
        //myState = GAMESTATE.RUNNING; // to allow for animations
        //run monster skill _skill
        //Debug.Log($"using skill {_skill}!");


        _curr.attackBar.Zero();
        _curr.OnTurnEnd();
        myState = GAMESTATE.TICKING;
    }   
    public void InitilizeCombatSW(){
        tick = 0;
        //calculate match bonuses/restrictions

        foreach (Monster mon in team){
            mon.attackBar.Zero();
            mon.OnEnterBattle();
        }
        //summoners war
        //increase tick and check for turn
        myState = GAMESTATE.TICKING;

        //pokemon
        //check selected moves for each monster, and order by priority
    }
    public void UpdateCombatSW(){
        if(myState != GAMESTATE.TICKING){
            return;
        }
        tick+= 1;
        //for each member on friendlyteam and enemy team, increment their atb by % of the speed

        foreach (Monster mon in team){
            mon.TickAttackBar(SPEEDPERCENT);
        }
        Array.Sort(team, new AttackBarComparer());
        //sort by atb and check if over 100
        if(team[0].attackBar.IsFull()){
            //Debug.Log($"{team[0].name}'s turn");
            //monster takes turn
            if(team[0].playerID == 1){
                //playerID of the current player
                selectedSkill = 1;
                myState = GAMESTATE.PLAYERTURN;
            }else{
                //enemies turn
                //call monster AI to pick move
                myState = GAMESTATE.ENEMYTURN;
                EnemyTurnChoice(team[0]);
            }
        }
    }
}
class AttackBarComparer : IComparer {
    public int Compare(object x, object y)
    {
        return ((new CaseInsensitiveComparer()).Compare(((Monster)y).attackBar.bar, ((Monster)x).attackBar.bar));
    }
}