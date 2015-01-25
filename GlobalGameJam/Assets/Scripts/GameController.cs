using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

	public BossController bossController;

	public PlayerStats playerStats;

	[Header("Player's Starting Stats")]
	public int startHealth;
	public int startStrength;
	public int startArmor;
	public int startFireStat;
	public int startWaterStat;
	public int startMagicStat;

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
    }

    void Start()
    {
        controller = this;
		SetupPlayerStats();
    }

    void Update()
    {

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
}
