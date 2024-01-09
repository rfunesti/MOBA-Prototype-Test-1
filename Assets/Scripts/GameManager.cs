using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour, IIntListener
{
    public Unit blueBase;
    public Unit redBase;
    public TextMeshProUGUI gameOverText;
    bool gameOver = false;

    private void Start()
    {
        blueBase.health.listeners.Add(gameObject);        
        redBase.health.listeners.Add(gameObject);        
    }

    public void IntUpdate(IntWrapper i)
    {
        if (i == blueBase.health) BlueBaseUpdate();
        else if (i == redBase.health) RedBaseUpdate();
    }

    public void BlueBaseUpdate()
    {
        if (blueBase.health.Value > 0 || gameOver) return;
        gameOverText.text = "RED TEAM WINS";
        StartCoroutine(GameOver());
    }

    public void RedBaseUpdate()
    {
        if (redBase.health.Value > 0 || gameOver) return;
        gameOverText.text = "BLUE TEAM WINS";
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        gameOver = true;
        while (Time.timeScale > 0f)
        {
            float alpha = gameOverText.color.a;
            alpha += Time.deltaTime;
            Color newColor = gameOverText.color; newColor.a = alpha;
            gameOverText.color = newColor;

            Time.timeScale -= Time.deltaTime;
            if (Time.timeScale < 0f) Time.timeScale = 0f;
            yield return null;
        }
    }
}
