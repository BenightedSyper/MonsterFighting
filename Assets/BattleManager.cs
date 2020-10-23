using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Monster[] team;

    public enum GAMESTATE { PLAYERTURN, ENEMYTURN, TICKING, PAUSE, RUNNING }
    public GAMESTATE myState;

    //private skillChoice chosenSkill = null;

    private int tick;
    // Start is called before the first frame update
    void Start()
    {
        myState = GAMESTATE.PAUSE;
        //create two monsters
        monOne = new Monster(0, 10, "Bulbasaur", Type.Grass, Type.Grass, new Stats(45,49,49,65,65,45));
        monTwo = new Monster(1, 10, "Charmander", Type.Fire, Type.Fire, new Stats(39,52,43,60,50,65));

        Monster test = new FireHellhound();
        //test.Print();

        team = new Monster[]{ monOne, monTwo, test };
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
                playerTurnChoice();
                break;
            case GAMESTATE.RUNNING:
            default:
                break;
        }
        

        //check for user input
        //based on game state
        //player turn

    }
    public void playerTurnChoice(){
        if(myState != GAMESTATE.PLAYERTURN){
            return;
        }
        Debug.Log("my turn");
    }   
    public void InitilizeCombatSW(){
        tick = 0;
        //calculate match bonuses/restrictions
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
            //monster takes turn
            myState = GAMESTATE.PLAYERTURN;
        }
    }
}
class AttackBarComparer : IComparer {
    public int Compare(object x, object y)
    {
        return ((new CaseInsensitiveComparer()).Compare(((Monster)y).attackBar.bar, ((Monster)x).attackBar.bar));
    }
}