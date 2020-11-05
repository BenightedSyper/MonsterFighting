using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {
    Fire,
    Water,
    Wind, 
    Grass
}
public enum ATTRIBUTE { HP, ATK, DEF, SPATK, SPDEF, SPD, ACC, RES };
public struct AttackBar{
    public double bar { get; set; }
    public void Increase(double _val){
        bar += _val;
    }
    public bool IsFull(){
        return (bar >= 100) ? true : false;
    }
    public void Zero(){
        bar = 0;
    }
}
public class Monster 
{
    public int playerID;
    private int id;
    private int level = 1;
    public string name;
    private Type primary = Type.Fire;
    private Type secondary = Type.Fire;

    public AttackBar attackBar;

    public int[] baseStats;
    public int[] levelStats;
    //public Gear[] equipment;
    public int[] runedStats;
    //public StatusEffect[] matchEffects;
    public int[] matchStats;
    public List<StatusEffect> statusEffects = new List<StatusEffect>();
    private float[] effectModifiers;
    public int[] currentStats;
    public Skill[] skills;

    public int baseHealth {
        get{
            return baseStats[0];
        }
        //set{ baseStats[0] = value; } i don't think the set methods need to be here
    }
    public int baseAttack {
        get{
            return baseStats[1];
        }
        //set{ baseStats[1] = value; }
    }
    public int baseDefense {
        get{
            return baseStats[2];
        }
        //set{ baseStats[2] = value; }
    }
    public int baseSpAttack {
        get{
            return baseStats[3];
        }
        //set{ baseStats[3] = value; }
    }
    public int baseSpDefense {
        get{
            return baseStats[4];
        }
        //set{ baseStats[4] = value; }
    }
    public int baseSpeed {
        get{
            return baseStats[5];
        }
        //set{ baseStats[5] = value; }
    }
    public int baseAccuracy{
        get{
            return baseStats[6];
        }
        //set{ baseStats[6] = value; }
    }
    public int baseResistance{
        get{
            return baseStats[7];
        }
        //set{ baseStats[7] = value; }
    }

    public int levelHealth {
        get{
            return levelStats[0];
        }
        //set{ levelStats[0] = value; }
    }
    public int levelAttack {
        get{
            return levelStats[1];
        }
        //set{ levelStats[1] = value; }
    }
    public int levelDefense {
        get{
            return levelStats[2];
        }
        //set{ levelStats[2] = value; }
    }
    public int levelSpAttack {
        get{
            return levelStats[3];
        }
        //set{ levelStats[3] = value; }
    }
    public int levelSpDefense {
        get{
            return levelStats[4];
        }
        //set{ levelStats[4] = value; }
    }
    public int levelSpeed {
        get{
            return levelStats[5];
        }
        //set{ levelStats[5] = value; }
    }
    public int levelAccuracy{
        get{
            return levelStats[6];
        }
        //set{ levelStats[6] = value; }
    }
    public int levelResistance{
        get{
            return levelStats[7];
        }
        //set{ levelStats[7] = value; }
    }

    public int runedHealth {
        get{
            return runedStats[0];
        }
        //set{ runedStats[0] = value; }
    }
    public int runedAttack {
        get{
            return runedStats[1];
        }
        //set{ runedStats[1] = value; }
    }
    public int runedDefense {
        get{
            return runedStats[2];
        }
        //set{ runedStats[2] = value; }
    }
    public int runedSpAttack {
        get{
            return runedStats[3];
        }
        //set{ runedStats[3] = value; }
    }
    public int runedSpDefense {
        get{
            return runedStats[4];
        }
        //set{ runedStats[4] = value; }
    }
    public int runedSpeed {
        get{
            return runedStats[5];
        }
        //set{ runedStats[5] = value; }
    }
    public int runedAccuracy{
        get{
            return runedStats[6];
        }
        //set{ runedStats[6] = value; }
    }
    public int runedResistance{
        get{
            return runedStats[7];
        }
        //set{ runedStats[7] = value; }
    }

    public int matchHealth {
        get{
            return matchStats[0];
        }
        //set{ matchStats[0] = value; }
    }
    public int matchAttack {
        get{
            return matchStats[1];
        }
        //set{ matchStats[1] = value; }
    }
    public int matchDefense {
        get{
            return matchStats[2];
        }
        //set{ matchStats[2] = value; }
    }
    public int matchSpAttack {
        get{
            return matchStats[3];
        }
        //set{ matchStats[3] = value; }
    }
    public int matchSpDefense {
        get{
            return matchStats[4];
        }
        //set{ matchStats[4] = value; }
    }
    public int matchSpeed {
        get{
            return matchStats[5];
        }
        //set{ matchStats[5] = value; }
    }
    public int matchAccuracy{
        get{
            return matchStats[6];
        }
        //set{ matchStats[6] = value; }
    }
    public int matchResistance{
        get{
            return matchStats[7];
        }
        //set{ matchStats[7] = value; }
    }

    public int currentHealth {
        get{
            return currentStats[0];
        }
        set{ 
            currentStats[0] = value; 
        }
    }
    public int currentAttack {
        get{
            return currentStats[1];
        }
        set{ 
            currentStats[1] = value; 
        }
    }
    public int currentDefense {
        get{
            return currentStats[2];
        }
        set{ 
            currentStats[2] = value; 
        }
    }
    public int currentSpAttack {
        get{
            return currentStats[3];
        }
        set{ 
            currentStats[3] = value; 
        }
    }
    public int currentSpDefense {
        get{
            return currentStats[4];
        }
        set{ 
            currentStats[4] = value; 
        }
    }
    public int currentSpeed {
        get{
            return currentStats[5];
        }
        set{ 
            currentStats[5] = value; 
        }
    }
    public int currentAccuracy{
        get{
            return currentStats[6];
        }
        set{
            currentStats[6] = value;
        }
    }
    public int currentResistance{
        get{
            return currentStats[7];
        }
        set{
            currentStats[7] = value;
        }
    }


    public Monster(){
        playerID = 0;
        name = "DEFAULT";
        level = 1;
        primary = Type.Fire;
        secondary = Type.Fire;
        //Base = new Stats();
        baseStats = new int[]{0,0,0,0,0,0};
        levelStats = new int[]{0,0,0,0,0,0};
        runedStats = new int[]{0,0,0,0,0,0};
        matchStats = new int[]{0,0,0,0,0,0};
        currentStats = new int[]{0,0,0,0,0,0};

        //Equipment = new Modifiers();
        //CurrentLevel = new Stats();
        CalculateCurrentLevelStats();
        attackBar = new AttackBar();
        skills = new Skill[4]{null, null, null, null};
    }

    public Monster(int id, int level, string name, Type primary, Type secondary, int[] _base){
        this.playerID = 0;
        this.id = id;
        this.level = level;
        this.name = name;
        this.primary = primary;
        this.secondary = secondary;
        baseStats = _base;
        levelStats = new int[]{0,0,0,0,0,0,0,0};
        runedStats = new int[]{0,0,0,0,0,0,0,0};
        matchStats = new int[]{0,0,0,0,0,0,0,0};
        currentStats = new int[]{0,0,0,0,0,0,0,0};

        effectModifiers = new float[8]{ 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };
        
        //CurrentLevel = new Stats();
        CalculateCurrentLevelStats();
        attackBar = new AttackBar();
        skills = new Skill[4]{null, null, null, null};
    }

    private void CalculateCurrentLevelStats(){
        levelStats[0] = BasedOnLevel(baseHealth);
        levelStats[0] += level + 5;
        levelStats[1] = BasedOnLevel(baseAttack);
        levelStats[2] = BasedOnLevel(baseDefense);
        levelStats[3] = BasedOnLevel(baseSpAttack);
        levelStats[4] = BasedOnLevel(baseSpDefense);
        levelStats[5] = BasedOnLevel(baseSpeed); //if not max level, you get fucked

        for(int i = 0; i < levelStats.Length; i++){
            runedStats[i] = levelStats[i];
            matchStats[i] = levelStats[i];
            currentStats[i] = levelStats[i];
        }
    }
    private void CalculateStatusEffectModifiers(){
        effectModifiers = new float[8]{1f,1f,1f,1f,1f,1f,1f,1f};
        foreach (StatusEffect se in statusEffects){
            for (int i = 0; i < effectModifiers.Length; i++){
                effectModifiers[i] *= se.modifiers[i];
            }
        }
        for (int i = 0; i < effectModifiers.Length; i++){
            //if any buffs effect health we will need to calculate the differently to avoid issues.
            currentStats[i] = Mathf.FloorToInt(matchStats[i] * effectModifiers[i]);
        }
    }

    private int BasedOnLevel(int _stat){
        return Mathf.CeilToInt( (2 * _stat) * level / 100) + 5;
    }
    public void SetPlayerID(int _id){
        this.playerID = _id;
    }
    public float TickAttackBar(double _percent){
        //Take monster speed multiply it by tick percent
        attackBar.Increase(_percent * levelSpeed);
        return 0;
    }

    public void Print(){
        Debug.Log("Printing Monster Information:");
        Debug.Log($"ID: {id}");
        Debug.Log($"Name: {name}");
        Debug.Log($"Level: {level}");
        Debug.Log($"Type: {primary} / {secondary}");
        Debug.Log("Base stats: ");
        //Base.Print();
        Debug.Log("Current Level Stats: ");
        //CurrentLevel.Print();
    }
    public float GetPercentHealth(){
        return (float) currentHealth / (float) matchHealth;
    }
    public float GetPercentAttackBar(){
        return (float) this.attackBar.bar / 100f;
    }
    public virtual int takeDamage (int _dam){ // probably needs to send a skillresponse back
        currentHealth -= _dam;
        //if health below 0 set knocked out
        //Debug.Log($"{name}: " + currentHealth);
        return _dam;
    }
    public virtual int gainHealth (int _val){
        currentHealth += _val;
        return _val;
    }
    public SkilletteResponse takeStatus(StatusEffect _se){
        SkilletteResponse response = new SkilletteResponse();
        switch (_se.statusType)
        {
            case STATUSEFFECTTYPE.DEFENSEBREAK:
            case STATUSEFFECTTYPE.ATTACKBREAK:
            default:
                bool found = false;
                foreach (StatusEffect se in statusEffects){
                    if(se.statusType == _se.statusType){
                        se.duration = Mathf.Max(se.duration, _se.duration);
                        found = true;
                    }
                }
                if(!found){
                    statusEffects.Add(_se);
                    CalculateStatusEffectModifiers();
                }
                break;
        }
        return response;
    }
    public virtual void OnEnterBattle(){
        //test for will set
        //
    }
    public virtual void OnExitBattle(){

    }
    public virtual void OnTurnStart(){
        //check for buffs/debuffs that have effects on the beginning of the turn life gain, DoTs
    }
    public virtual void OnTurnEnd(){
        List<StatusEffect> toRemove = new List<StatusEffect>();
        foreach (StatusEffect se in statusEffects){
            se.duration--;
            if(se.duration <= 0){
                toRemove.Add(se);
            }
        }
        foreach (StatusEffect re in toRemove){
            statusEffects.Remove(re);
        }
        
        //Debug.Log($"{this.name} has {statusEffects.Count} debuffs");
    }
    public virtual void OnDeath(){

    }
}
