using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

	public BossController bossController;

	public PlayerStats playerStats;
    public static GameObject player;

	[Header("Player's Starting Stats")]
	public int startHealth;
	public int startStrength;
	public int startArmor;
	public int startFireStat;
	public int startWaterStat;
	public int startMagicStat;

    public bool dead;

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

	void SetupPlayerStats()
	{
		playerStats = new PlayerStats();
		playerStats.Health = startHealth;
		playerStats.Strength = startStrength;
		playerStats.Armor = startArmor;

		ElementStat genericStat;
		genericStat.type = ElementType.Fire;
		genericStat.value = startFireStat;
		playerStats.FireStat = genericStat;

		genericStat.type = ElementType.Water;
		genericStat.value = startWaterStat;
		playerStats.WaterStat = genericStat;

		genericStat.type = ElementType.Magic;
		genericStat.value = startMagicStat;
		playerStats.MagicStat = genericStat;
	}

    public int GetHealth()
    {
        return playerStats.Health;
    }

    public void TakeDamage()
    {
        playerStats.Health = -1;
        if (playerStats.Health <= 0) dead = true;
    }
}
