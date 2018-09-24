using UnityEngine;
using UnityEngine.UI;
//Henrik, Character stats take are intractable trouhg input.
public class CharacterStats : MonoBehaviour {
    //accsess to menu script.
    public MenuScript menuScript;
    //Characters stats
    //Current Health and MaxHealth for the character.
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    //current XP and required xp to level up.
    public float currentXp { get; set; }
    public float requiredXpToLevelUp { get; set; }
    //DMG values, magic, attack
    public float attackDmg { get; set; }
    public float magicDmg { get; set; }
    //Current Mana, Max Mana, Mana Regenration, Mana Cost for the spell cost.
    public float currentMana { get; set; }
    public float maxMana { get; set; }
    public float manaRegeneration { get; set; }
    public float manaCost { get; set; }
    //Defensive and Regeneration
    public float defensiveRate { get; set; }
    public float regenerationRate { get; set; }
    //Character level and player stats and availableskillpoints.
    public float characterLevel { get; set; }
    public int availableSkillPoints { get; set; }
    public float characterSkillStrength { get; set; }
    public float characterSkillStamina { get; set; }
    public float characterSkillLuck { get; set; }
    public float characterSkillIntelegence { get; set; }
    public float attackDmgCritInc { get; set; }
    //walking speed, runing speed, and base speed.
    public float playerSpeed { get; set; }
    public float walkingSpeed { get; set; }
    public float runningSpeed { get; set; }
    //Slider to display the stats
    public Slider healthBar;
    public Slider xpBar;
    public Slider magicBar;
    //Text to display statis
    public Text healthDisplay;
    public Text magicDisplay;
    public Text xpDisplay;
    public Text showLevel;
    public Text showDMG;
    public Text showMagicDMG;
    public Text showDefence;
    public Text showRegeneration;
    public Text showCritRate;
    public Text showAvailableSkillPoints;
    public Text showStrength;
    public Text showIntelegence;
    public Text showStamina;
    public Text showLuck;
    //panel to interact when player is dead
    public GameObject gameOverPanel;
    //Levelup sound clip
    public AudioClip levelUpSound;
    public AudioSource audio;


    // Defining the player at the start.
    void Awake () {
        characterLevel = 1.0f;
        currentXp = 0.0f;
        requiredXpToLevelUp = 200.0f;
        maxMana = 200.0f;
        currentMana = maxMana;
        manaCost = 40.0f;
        attackDmg = 5.0f;
        defensiveRate = 1.0f;
        regenerationRate = 0.02f;
        availableSkillPoints = 1;
        characterSkillStrength = 1.0f;
        characterSkillIntelegence = 1.0f;
        characterSkillStamina = 1.0f;
        characterSkillLuck = 1.0f;
        CalculateHP();
        FillHealth();
        walkingSpeed = 5.0f;
        runningSpeed = 10.0f;

        xpBar.value = CalculateCurrentXp();
        healthBar.value = CalculateCurrentHealth();
        magicBar.value = CalculateCurrentMagic();
        FadeTextController.Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        //if you press y you take dmg.
        if (Input.GetKeyDown(KeyCode.Y))
        {
            float dmg = CalculateDmgDealt();
            TakeDmg(dmg);
        }        
        //if you press U you get 50% earned XP
        if (Input.GetKeyDown(KeyCode.U))
        {
            GainXp(requiredXpToLevelUp / 2);
        }
        //If you press I cast spell on your self.
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (currentMana >= manaCost) { 
            CastSpell(magicDmg, manaCost);
            }
        }
        //if you hold in Left Shift key you run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = runningSpeed;
        }
        //if you release the button you walk again
        else
        {
            playerSpeed = walkingSpeed;
        }
        //if you dont have full health you can regenerate health
        if (maxHealth > currentHealth)
        {
            RegenHealth();
        }
        //if you dont have mana regain mana
        if (maxMana > currentMana)
        {
            RegenMana();
        }
        //Update the xp bar and the text for the xpbar
        CalculateDMG();
        CalucateMagicDmg();
        CalculateHP();
        CalculateHealthRegen();
        CalculateManaRegen();
        CheckXP();
        healthBar.value = CalculateCurrentHealth();
        magicBar.value = CalculateCurrentMagic();
        xpBar.value = CalculateCurrentXp();
        healthDisplay.text = Mathf.Round(currentHealth) + "/" + maxHealth;
        magicDisplay.text = Mathf.Round(currentMana) + "/" + maxMana;
        xpDisplay.text = currentXp + "/" + requiredXpToLevelUp;
        showLevel.text = "Level: " + characterLevel;
        showDMG.text = "Attack DMG: " + attackDmg;
        showMagicDMG.text = "Magic DMG: " + magicDmg;
        showDefence.text = "Defensive Rate: " + defensiveRate;
        showRegeneration.text = "Regneration Rate: " + regenerationRate;
        showAvailableSkillPoints.text = availableSkillPoints.ToString();
        showCritRate.text = "CritRate: " + CalculateCritRate().ToString();
        showStrength.text = characterSkillStrength.ToString();
        showIntelegence.text = characterSkillIntelegence.ToString();
        showStamina.text = characterSkillStamina.ToString();
        showLuck.text = characterSkillLuck.ToString();
        
    }
    //Method for player taking dmg
    void TakeDmg(float DmgValue) {
        float actualDMG = DmgValue * defensiveRate;
        currentHealth -= actualDMG;
        FadeTextController.CreateFloatingText(actualDMG.ToString(), transform, "HP");
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }
    void CastSpell(float magicDmg, float manaCost)
    {
        print("Casting: FireBaller,you hit your self stopid");
        currentMana -= manaCost;
        FadeTextController.CreateFloatingText(manaCost.ToString(), transform, "MP");
        TakeDmg(magicDmg);
    }
    //method to manage what happens when the player recieves xp.
    void GainXp(float GainedXp)
    {
        if (characterLevel < 20) { 
        currentXp += GainedXp;
        FadeTextController.CreateFloatingText(GainedXp.ToString(), transform, "XP");
        }
        else
        {
            print("MAXLVL");
        }
    }
    void CheckXP()
    {
        if (currentXp >= requiredXpToLevelUp)
        {
            LevelUp();
        }
        if (characterLevel >= 20 && currentXp > 0.0f)
        {
            currentXp = 0.0f;
        }
    }
    //Methods to calculate percentage for sliders.
    float CalculateCurrentHealth()
    {
        return currentHealth / maxHealth;
    }
    float CalculateCurrentXp()
    {
        return currentXp / requiredXpToLevelUp;
    }
    float CalculateCritRate()
    {
        float crit = 0;
        crit = 0.04f * characterSkillLuck;
        return crit;
    }

    float CalculateCurrentMagic()
    {
        return currentMana / maxMana;
    }
    float CalculateDmgDealt()
    {
        attackDmgCritInc = attackDmg;
        float random = Random.Range(0.0f, 1.0f);
        if (random < CalculateCritRate())
        {
            return attackDmgCritInc * 1.5f;
        }
        else
        {
            return attackDmgCritInc;
        }
    }
    void CalculateHP()
    {
        maxHealth = 20.0f * (0.5f * (characterLevel + (characterSkillStamina * 10) + 1));
    }
    void CalculateDMG()
    {
        attackDmg = 5.0f * (0.5f * (characterLevel + (characterSkillStrength * 10) + 1));
    }
    void CalculateHealthRegen()
    {
        if (regenerationRate < 1.0f)
        {
            regenerationRate = 0.02f * ((characterLevel / 4) + (characterSkillStamina * 2));
        }
    }
    void CalculateManaRegen()
    {
        if (manaRegeneration < 2.0f)
        {
            manaRegeneration = 0.02f * ((characterLevel / 4) + (characterSkillIntelegence * 2.5f)); 
        }
    }
    void CalucateMagicDmg()
    {
        magicDmg = 3.0f * (0.7f * (characterLevel + (characterSkillIntelegence * 10) + 1));
    }
    //Method to handle what happens when the player dies.
    void Die()
    { 
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(this);
    }
    //Handles the health regeneration
    void RegenHealth()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else { 
        currentHealth += (regenerationRate / 4);
        }
    }
    void RegenMana()
    {
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        else
        {
            currentMana += (manaRegeneration / 4);
        }
    }
    void FillHealth() {
        currentHealth = maxHealth;
    }
    //what happens when the player levels up.
    void LevelUp()
    {
        CalculateHP();
        if (characterLevel < 20) {
        audio.PlayOneShot(levelUpSound);
        characterLevel++;
        availableSkillPoints++;
        currentXp = currentXp - requiredXpToLevelUp;
        requiredXpToLevelUp = characterLevel * 200.0f;
        CalculateHP();
            if (defensiveRate > 0.2f){ 
        defensiveRate = 1.0f - (0.02f * (characterLevel));
            }
        }
        FillHealth();
    }
    public void AddStrength()
    {
        print("Add Strength");
        if (availableSkillPoints > 0)
        {
            characterSkillStrength++;
            availableSkillPoints--;
        }
    }
    public void AddStamina()
    {
        print("Add Stamina");
        if (availableSkillPoints > 0)
        {
            characterSkillStamina++;
            availableSkillPoints--;
        }
    }
    public void AddLuck()
    {
        print("Add Luck");
        if (availableSkillPoints > 0)
        {
            characterSkillLuck++;
            availableSkillPoints--;
        }
    }
    public void AddIntelegence()
    {
        print("Add Intelegence");
        if (availableSkillPoints > 0) { 
        characterSkillIntelegence++;
        availableSkillPoints--;
        }
    }
}
