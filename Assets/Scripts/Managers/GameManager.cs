using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public GameObject player;
    public GameObject boss;

    public int initialHealth;

    public Text healthDisplay;

    private int health;
    private int points;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Start()
    {
        health = initialHealth;
        if (healthDisplay) {
            healthDisplay.text = "Lives: " + health;
        }
        if (boss)
        {
            boss.SetActive(false);
        }
    }

    public void TriggerBossFight()
    {
        boss.SetActive(true);
    }

    public void TakeDamage(int damage) {
        // TODO temproray invurnability
        health -= damage;

        if (healthDisplay)
        {
            healthDisplay.text = "Lives: " + health;
        }
    }
}
