using System.Collections;
using UnityEngine;

public class FruitCreator : MonoBehaviour
{
    [SerializeField] GameObject[] fruits;
    [SerializeField] float pushSpeed = 1f;

    void Start()
    {
        StartCoroutine(FruitGenerator());
    }

    IEnumerator FruitGenerator()
    {
        while (true)
        {
            int index = Random.Range(0, fruits.Length);
            GameObject newFruit = Instantiate(fruits[index]);
            newFruit.transform.position = transform.position;
            newFruit.transform.SetParent(transform);
            yield return new WaitForSeconds(pushSpeed);
        }
    }

    public GameObject GetFruit()
    {
        int index = Random.Range(0, fruits.Length);
        GameObject returnedFruit = fruits[index];
        if (returnedFruit.tag == "Rotten")
        {
            return GetFruit();
        }
        else
        {
            return returnedFruit;
        }
    }
}