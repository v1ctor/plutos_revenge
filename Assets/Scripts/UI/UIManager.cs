using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text healthText;
    public Text bosstHealthText;

	// Use this for initialization
	void Start () {
        bosstHealthText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance)
        {
            UpdateHealthDisplay(GameManager.instance.Health);
            if (GameManager.instance.HasBoss()) {
                UpdateBossHealthDisplay(GameManager.instance.BossHealth);
            }
        }
	}

    void UpdateHealthDisplay(int health) {
        healthText.text = "LIVES: " + health;
    }

    void UpdateBossHealthDisplay(int health) {
        bosstHealthText.text = "BOSS LIVES: " + health;
        bosstHealthText.gameObject.SetActive(true);
    }
}
