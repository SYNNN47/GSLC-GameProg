using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private int maxHp = 100;
    private int currHp;
    public TMP_Text hpText;
    private string gameOverScene = "GameOver";
    // Start is called before the first frame update
    void Start()
    {
        currHp = maxHp;
        UpdateHPUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Annoyance"))
        {
            currHp -= 25;
            Debug.Log("Player Hit! Current HP: " + currHp);
            UpdateHPUI();

            if(currHp <= 0)
            {
                Debug.Log("Player is dead. Loading Game Over Scene.");
                SceneManager.LoadScene(gameOverScene);
            }
        }
    }

    // Update is called once per frame
    void UpdateHPUI()
    {
        if(hpText != null)
        {
            hpText.text = "HP: " + currHp;
        }
    }
}
