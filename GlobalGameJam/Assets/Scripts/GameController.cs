using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    #region Public
    public static GameController controller;

    [HideInInspector]
    public HeartController heartController;
    [HideInInspector]
    public ChestController chestController;
    [HideInInspector]
    public FireballController fireballController;
    [HideInInspector]
    public XpController xpController;
    [HideInInspector]
    public CurrencyController currencyController;
	public BossController bossController;
    public UIController uiController;
	public PlayerStats playerStats;
    public static GameObject player;
    public MasterPool masterPool;

	[Header("Player's Starting Stats")]
	public int startHealth = 3;
	public int startStrength = 1;
	public int startArmor = 1;
	public int startFireStat = 1;
	public int startWaterStat = 1;
	public int startMagicStat = 1;

    public bool dead;
    #endregion

    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        player = GameObject.Find("Player");
        masterPool = GetComponent<MasterPool>();
        heartController = GetComponent<HeartController>();
        fireballController = GetComponent<FireballController>();
        currencyController = GetComponent<CurrencyController>();
        xpController = GetComponent<XpController>();
        chestController = GetComponent<ChestController>();
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    void Start()
    {
        controller = this;
		SetupPlayerStats();
    }

    void Update()
    {
        if(dead)
        {
            dead = false;
            Application.LoadLevel("GameOver");
        }

    }

    void FixedUpdate()
    {
        UpdateStats();
    }

    void UpdateStats()
    {
        if (playerStats.Xp >= playerStats.XpStep)
        {
            playerStats.XpStep = playerStats.XpStep;
            playerStats.Level = 1; //Add a level
        }
    }

	void SetupPlayerStats()
	{
		playerStats = new PlayerStats();
		playerStats.Health = startHealth;
		playerStats.Strength = startStrength;
		playerStats.Armor = startArmor;

		ElementStat genericStat;
		genericStat.type = Element.Fire;
		genericStat.value = startFireStat;
		playerStats.FireStat = genericStat;

		genericStat.type = Element.Water;
		genericStat.value = startWaterStat;
		playerStats.WaterStat = genericStat;

		genericStat.type = Element.Magic;
		genericStat.value = startMagicStat;
		playerStats.MagicStat = genericStat;
	}

    public int GetHealth()
    {
        return playerStats.Health;
    }

    public float GetXp()
    {
        return playerStats.Xp;
    }

    public float GetLevel()
    {
        return playerStats.Level;
    }

    public void GainXp(float value)
    {
        playerStats.Xp = value;
    }

    public void TakeDamage()
    {
        playerStats.Health = -1;
        if (playerStats.Health <= 0) dead = true;
        uiController.UpdateHearts();
    }
}
