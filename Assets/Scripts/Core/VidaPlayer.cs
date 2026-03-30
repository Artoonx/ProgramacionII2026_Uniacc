using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public int maxhealt = 3;
    private int currenthealth;
    void Start()
    {
        currenthealth = maxhealt;
    }

    public void Takedamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            die();
        }
        
         
    }

    public void die()
    {
        GameManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
