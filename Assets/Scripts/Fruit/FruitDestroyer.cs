using UnityEngine;
using TMPro;

public class FruitDestroyer : MonoBehaviour
{
    [SerializeField] EndGame endGame;
    [SerializeField] TMP_Text missedText;
    [SerializeField] int maxMissedRottenFruit = 3;

    int missedRottenFruit = 0;

    void Start()
    {
        missedText.text = missedRottenFruit.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fruit")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Rotten")
        {
            Destroy(other.gameObject);
            missedRottenFruit++;
            missedText.text = missedRottenFruit.ToString();
            if(missedRottenFruit >= maxMissedRottenFruit)
            {
                endGame.Defeat();
            }
        }
    }
}