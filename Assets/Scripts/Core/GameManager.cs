using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coinCount = 0;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;           
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        coinText.text = "x" + coinCount;
    }
    public void CollectCoin(int amount)
    {
        coinCount += amount;
        coinText.text = "x" + coinCount;
        Debug.Log("Coins: " + coinCount);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        Invoke("restLevel", 2f);
    }

    void restLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
