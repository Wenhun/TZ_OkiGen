using UnityEngine;
using TMPro;

public class ScoreChecker : MonoBehaviour
{
    [SerializeField] PlacerInBasket placerInBasket;
    [SerializeField] TMP_Text countPlace;
    [SerializeField] TMP_Text leftToCollect;

    QuestGenerator questGenerator;
    EndGame endGame;

    FruitName fruitToCollect;
    int countToCollect;
    int countPlaceInBasket;

    int rightFruitInBasket = 0;

    void Start()
    {
        questGenerator = GetComponent<QuestGenerator>();
        endGame = GetComponent<EndGame>();
        fruitToCollect = questGenerator.GetFruitToCollect();
        countToCollect = questGenerator.GetCountToCollect();
        countPlaceInBasket = placerInBasket.GetCountPlaceInBasket();
        countPlace.text = countPlaceInBasket.ToString();
        leftToCollect.text = countToCollect.ToString();
    }

    public void GameStatusCheck(FruitName fruit)
    {
        countPlaceInBasket--;
        countPlace.text = countPlaceInBasket.ToString();
        if(fruit == fruitToCollect)
        {
            rightFruitInBasket++;
            leftToCollect.text = (countToCollect - rightFruitInBasket).ToString();
        }
            
        if(rightFruitInBasket == countToCollect)
        {
            endGame.Win();
        }
        if(placerInBasket.BasketIsFool())
        {
            endGame.Defeat();
        }   
    }
}