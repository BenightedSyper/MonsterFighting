using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public Monster[] team;

    public enum GAMESTATE { PLAYERTURN, ENEMYTURN, TICKING, PAUSE, RUNNING }
    public GAMESTATE myState;

    public Texture2D emptyProgressBar;
    public Texture2D fullProgressBar;

    //private skillChoice chosenSkill = null;

    private int tick;
    // Start is called before the first frame update
    void Start()
    {
        myState = GAMESTATE.PAUSE;
        //create two monsters
        monOne = new Monster(0, 10, "Bulbasaur", Type.Grass, Type.Grass, new Stats(45,49,49,65,65,45));
        monTwo = new Monster(1, 10, "Charmander", Type.Fire, Type.Fire, new Stats(39,52,43,60,50,65));

        hell = new FireHellhound();
        hell.SetPlayerID(1);
        //test.Print();

        team = new Monster[]{ monOne, monTwo, hell };
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
        
        double per = hell.attackBar.bar /100;
        //Debug.Log(per);
        per *= Screen.width;
        GUI.DrawTexture(new Rect(0, 70, Screen.width, 50), emptyProgressBar);
        GUI.DrawTexture(new Rect(0, 80, (float)per, 30), fullProgressBar);
        
        switch (myState)
        {
            case GAMESTATE.PLAYERTURN:
                if (GUI.Button(new Rect(10, 10, 50, 50), "Skill 1" )){
                    PlayerTurnChoice(1);
                }
                if (GUI.Button(new Rect(70, 10, 50, 50), "Skill 2" )){
                    PlayerTurnChoice(2);
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
        myState = GAMESTATE.TICKING;
    }
    public void PlayerTurnChoice(int _skill){
        if(myState != GAMESTATE.PLAYERTURN){
            return;
        }
        //myState = GAMESTATE.RUNNING; // to allow for animations
        //run monster skill _skill
        Debug.Log($"using skill {_skill}!");
        team[0].attackBar.Zero();

        myState = GAMESTATE.TICKING;
    }   
    public void InitilizeCombatSW(){
        tick = 0;
        //calculate match bonuses/restrictions

        /*
        foreach (Monster mon in team){
            mon.OnEnterBattle();
        }
        */

        //set attack bar to 0 for all monsters
        //monOne.attackBar.Zero();
        //monTwo.attackBar.Zero();
        foreach (Monster mon in team){
            mon.attackBar.Zero();
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
            Debug.Log($"{team[0].name}'s turn");
            //monster takes turn
            if(team[0].playerID == 1){
                //playerID of the current player
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