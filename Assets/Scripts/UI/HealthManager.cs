using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    // UI assets
    public GameObject HealthBar;
    public List<GameObject> health;

    // Floats
    int CurrentHealth = 3;

    void Update()
    {
        CurrentHealth = GetComponent<PlayerController>().lives;
        if (CurrentHealth == 2.0f)
        {
            health[1].SetActive(true);
            health[2].SetActive(false);
        }
        if (CurrentHealth == 1.0f)
        {
            health[0].SetActive(true);
            health[1].SetActive(false);
        }
        // 
        if (CurrentHealth == 0.0f)
        {
            health[0].SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void PlayerDamaged(int amount)
    {
        CurrentHealth -= amount;
    }

    public void PlayerHeal(int amount)
    {
        CurrentHealth += amount;
    }
}
