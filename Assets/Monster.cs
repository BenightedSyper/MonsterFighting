using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {
    Fire,
    Water,
    Wind, 
    Grass
}

public struct Stats {
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int SpAttack { get; set; }
    public int SpDefense { get; set; }
    public int Speed { get; set; }

    public Stats(int _h = 100, int _a = 10, int _d = 10, int _sa = 10, int _sd = 10, int _s = 100){
        Health = _h;
        Attack = _a;
        Defense = _d;
        SpAttack = _sa;
        SpDefense = _sd;
        Speed = _s;
    }
    public void Print(){
        Debug.Log($"HP: {Health}");
        Debug.Log($"Attack: {Attack}");
        Debug.Log($"Defense: {Defense}");
        Debug.Log($"SpAttack: {SpAttack}");
        Debug.Log($"SpDefense: {SpDefense}");
        Debug.Log($"Speed: {Speed}");
    }
}
public struct Modifiers {
    public int FlatHealth { get; set; }
    public int FlatAttack { get; set; }
    public int FlatDefense { get; set; }
    public int FlatSpAttack { get; set; }
    public int FlatSpDefense { get; set; }
    public int FlatSpeed { get; set; }
    public int PercentHealth { get; set; }
    public int PercentAttack { get; set; }
    public int PercentDefense { get; set; }
    public int PercentSpAttack { get; set; }
    public int PercentSpDefense { get; set; }
    public int PercentSpeed { get; set; }

    public Modifiers(int _fh = 0, int _fa = 0, int _fd = 0, int _fsa = 0, int _fsd = 0, int _fs = 0, 
                     int _ph = 1, int _pa = 1, int _pd = 1, int _psa = 1, int _psd = 1, int _ps = 1){
        FlatHealth = _fh;
        FlatAttack = _fa;
        FlatDefense = _fd;
        FlatSpAttack = _fsa;
        FlatSpDefense = _fsd;
        FlatSpeed = _fs;
        PercentHealth = _ph;
        PercentAttack = _pa;
        PercentDefense = _pd;
        PercentSpAttack = _psa;
        PercentSpDefense = _psd;
        PercentSpeed = _ps;
    }
}
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
    public Stats Base;
    public Modifiers Equipment;
    public Stats CurrentLevel;
    public AttackBar attackBar;

    public Skill skill1;
    
    public Monster(){
        playerID = 0;
        name = "DEFAULT";
        level = 1;
        primary = Type.Fire;
        secondary = Type.Fire;
        Base = new Stats();
        Equipment = new Modifiers();
        CurrentLevel = new Stats();
        CalculateCurrentLevelStats();
        attackBar = new AttackBar();
        skill1 = new Skill(this);
    }

    public Monster(int id, int level, string name, Type primary = default, Type secondary = default, Stats @base = default){
        this.playerID = 0;
        this.id = id;
        this.level = level;
        this.name = name;
        this.primary = primary;
        this.secondary = secondary;
        Base = @base;
        CurrentLevel = new Stats();
        CalculateCurrentLevelStats();
        attackBar = new AttackBar();
        skill1 = new Skill(this);
    }

    private void CalculateCurrentLevelStats(){
        CurrentLevel.Health = BasedOnLevel(Base.Health);
        CurrentLevel.Health += level + 5;
        CurrentLevel.Attack = BasedOnLevel(Base.Attack);
        CurrentLevel.Defense = BasedOnLevel(Base.Defense);
        CurrentLevel.SpAttack = BasedOnLevel(Base.SpAttack);
        CurrentLevel.SpDefense = BasedOnLevel(Base.SpDefense);
        CurrentLevel.Speed = BasedOnLevel(Base.Speed); //if not max level, you get fucked
    }

    private int BasedOnLevel(int _stat){
        return Mathf.CeilToInt( (2 * _stat) * level / 100) + 5;
    }
    public void SetPlayerID(int _id){
        this.playerID = _id;
    }
    public float TickAttackBar(double _percent){
        //Take monster speed multiply it by tick percent
        attackBar.Increase(_percent * CurrentLevel.Speed);
        return 0;
    }

    public void Print(){
        Debug.Log("Printing Monster Information:");
        Debug.Log($"ID: {id}");
        Debug.Log($"Name: {name}");
        Debug.Log($"Level: {level}");
        Debug.Log($"Type: {primary} / {secondary}");
        Debug.Log("Base stats: ");
        Base.Print();
        Debug.Log("Current Level Stats: ");
        CurrentLevel.Print();
    }
    public float GetPercentHealth(){
        return 1f;
    }
    public float GetPercentAttackBar(){
        return (float) this.attackBar.bar / 100f;
    }
    public virtual int takeDamage (int _dam){
        CurrentLevel.Health -= 10;
        //if health below 0 set knocked out
        Debug.Log($"{name}: " + CurrentLevel.Health);
        return 10;
    }
    public virtual int gainHealth (int _val){
        CurrentLevel.Health += _val;
        return _val;
    }

    public virtual void OnEnterBattle(){
        //test for will set
        //
    }
    public virtual void OnExitBattle(){

    }
    public virtual void OnTurnStart(){

    }
    public virtual void OnTurnEnd(){

    }
    public virtual void OnDeath(){

    }
}
