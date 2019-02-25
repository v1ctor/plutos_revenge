using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public int initialHealth;
    public float temporaryInvulnerabilityInterval = 3f;

    public int Health { set; get; }

    private float invulnerabilityStopTime;
    private bool invulnerability = false;
    private Animator playerAnimator;
    private GameObject player;

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
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        Health = initialHealth;
        invulnerabilityStopTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > invulnerabilityStopTime)
        {
            invulnerability = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (invulnerability)
        {
            return;
        }
        Health -= damage;

        if (Health <= 0)
        {
            GameOver();
            return;
        }
        StartInvulnerability();
    }

    public void GameOver()
    {
        GameSceneManager.instance.RestartLevel();
    }


    private bool HasInvulnerability()
    {
        return Time.time < invulnerabilityStopTime;
    }

    private void StartInvulnerability()
    {
        invulnerability = true;
        invulnerabilityStopTime = Time.time + invulnerabilityStopTime;
        playerAnimator.SetTrigger("Invulnerable");
    }

}
