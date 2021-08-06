using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character{

        public string name;
        public int exp=0;


        public Character(){

                name = "Not assigned";

        }

        public Character(string name){
            this.name = name;

        }

        public virtual void PrintStatInfo(){
            Debug.LogFormat("Nome:{0} - XP:{1}",name,exp);
        }

}

public class Paladin: Character{

    public Weapon weapon;
    public Paladin(string name,Weapon weapon): base(name){
      this.weapon = weapon;
    }

    public override void PrintStatInfo(){
      Debug.LogFormat("Hail {0} - Take up your {1}!", name, weapon.name);
    }

}

public struct Weapon{

    public string name;
    public int damage;

    public Weapon(string name, int damage){
        this.name = name;
        this.damage = damage;
    }

    public void PrintWeaponInfo(){
            Debug.LogFormat("Nome:{0} - Dano:{1}",name,damage);
        }

}
