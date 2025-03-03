 using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Text txtLives;
    [SerializeField] private Text txtCoins;
    [SerializeField] private Text txtTime;
    [SerializeField] private Text txtScore;

    private int currentTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        StartCoroutine(CountdownTime());
        txtCoins.text = "Coins: " + GameManager.Instance.Coins;
        txtScore.text = "Score: " + GameManager.Instance.Score; 
        txtLives.text = "Lives: " + GameManager.Instance.Lives;
        txtTime.text  = "Time: " + GameManager.Instance.Time;

    }
    //Cuenta atras
    private IEnumerator CountdownTime()
    {
        while (GameManager.Instance.Time > 0)
        {
            GameManager.Instance.SubstractTime();
            yield return new WaitForSeconds(1f);
            
        }
        Mario mario = FindObjectOfType<Mario>();
        if (mario != null)
        {
            GameManager.Instance.SubstractLives();
        }
    }

    public void Update()
    {
        txtLives.text = "Lives: " + GameManager.Instance.Lives;
        txtCoins.text = "Coins: " + GameManager.Instance.Coins;
        txtScore.text = "Score: " + GameManager.Instance.Score; 
        txtTime.text  = "Time: " + GameManager.Instance.Time;
    }
}


