using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstats : MonoBehaviour {
    //Players current level starts at lvl 0 so that the player can level once at the beginning, also experiance system
    public float playerLevel = 0.0f;
    public float XP = 0.0f;
    public float maxXP = 20.0f;

    //Max Health, current HealthPoints and the rate of regeneration.
    public float maxHP = 20.0f;
    public float HP = 20.0f;
    public float RegenRate = 0.02f;

    //Attack Power dealt to Enemies and the amount of damage negation.
    public float AttackDMG = 5.0f;
    public float DefensiveRate = 0.9f;

	void Start () {
		
	}

	void Update () {

        //Passive Healthregeneration that can be altered. Checks if current HP is less than maxHP.
        if (HP < maxHP)
        {
            regenHealth();
        }
        //if you go over then you get maxHP, this way you want have more health than max by going over.
        if (HP > maxHP)
        {
            HP = maxHP;
        }
        //if you dead you dead no more playing.
        if (HP <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        //If you have enough xp to level up
        if (XP >= maxXP)
        {
            levelUp();
        }
	}

    //Method for taking DMG also takes the DefensiveRate into account.
    public void takeDMG(float DMGTaken) { HP -= DMGTaken * DefensiveRate; }
    //Upgrade methods.
    public void UpgradeAttackDMG(float Upgrade) { AttackDMG += Upgrade; }
    public void UpgradeDefensiveRate(float Upgrade) { DefensiveRate -= Upgrade; }
    public void UpgradeHealthRegen(float Upgrade) { RegenRate += Upgrade; }
    //Regen method.
    void regenHealth() { HP += RegenRate; }
    //Levelup method.
    void levelUp() {
        //Increase level by 1.
        playerLevel++;
        //Set currentxp to the amount over maxXP
        XP = XP - maxXP;
        //Require more XP from player to next level up.
        maxXP = maxXP * 1.5f;
        //Upgrade player stats.
        float AtkUpg = playerLevel * 1.5f;
        float DrUpg = playerLevel * 0.05f;
        float HrUpg = playerLevel * 0.01f;
        UpgradeAttackDMG(AtkUpg);
        UpgradeDefensiveRate(DrUpg);
        UpgradeHealthRegen(HrUpg);
    }   
}
