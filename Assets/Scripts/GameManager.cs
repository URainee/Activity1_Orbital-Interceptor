using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score;
    public TextMeshProUGUI Scoretext;

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
    
    public void AddScore(int value)
    {
        score += value;
    }

    public void DeductScore(int value)
    {
        score -= value;
    }

    void Update()
    {
        Scoretext.text = score.ToString();
    }
}
