using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool clicked = false;
    public FruitName fruitName;

    void Update()
    {
        if (clicked)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
