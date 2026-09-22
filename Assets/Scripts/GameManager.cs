using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score;
    public TextMeshProUGUI Scoretext;

    private void OnDisable()
    {
        Debug.Log("Game Closed...");
    }

    private void OnEnable()
    {
        Debug.Log("Game Started!!");
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    public void DeductScore(int value)
    {
        score -= value;
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    private void Start()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        Scoretext.text = "Score: " + score.ToString();
    }
}
