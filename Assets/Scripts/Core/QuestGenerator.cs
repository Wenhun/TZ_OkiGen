using UnityEngine;
using TMPro;

public class QuestGenerator : MonoBehaviour
{
    [SerializeField] FruitCreator fruitCreator;
    [SerializeField] MeshFilter fruitUI;
    [SerializeField] TMP_Text countUI;
    [SerializeField, Range(1, 4)] int minimumRandomNumber = 1;
    [SerializeField, Range(2, 5)] int maximumRandomNumber = 5;

    int countToCollect;
    GameObject fruitToCollect;

    void Awake()
    {
        if(minimumRandomNumber >= maximumRandomNumber) 
        {
            Debug.LogError("Set minimum number smaller than maximum number in QuestGenerator. Numbers setup to default");
            minimumRandomNumber = 1;
            maximumRandomNumber = 5;
        }
        countToCollect = Random.Range(minimumRandomNumber, maximumRandomNumber + 1);
        fruitToCollect = fruitCreator.GetFruit();
        PrintToUI();
    }

    private void PrintToUI()
    {
        fruitUI.mesh = fruitToCollect.GetComponent<MeshFilter>().sharedMesh;
        fruitUI.GetComponent<MeshRenderer>().material = fruitToCollect.GetComponent<MeshRenderer>().sharedMaterial;
        countUI.text = "Collect " + countToCollect.ToString() + " " + fruitToCollect.GetComponent<Fruit>().fruitName;
    }

    public int GetCountToCollect()
    {
        return countToCollect;
    }

    public FruitName GetFruitToCollect()
    {
        return fruitToCollect.GetComponent<Fruit>().fruitName;
    }
}
