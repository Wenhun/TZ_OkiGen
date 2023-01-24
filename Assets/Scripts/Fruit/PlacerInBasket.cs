using System.Collections.Generic;
using UnityEngine;

public class PlacerInBasket : MonoBehaviour
{
    [SerializeField] List<Transform> places = new List<Transform>();

    Dictionary<Transform, Transform> fruitPlace;

    int countPlace;

    bool basketIsFool = false;

    void Start()
    {
        fruitPlace = new Dictionary<Transform, Transform>();
        foreach(Transform place in places)
        {
            fruitPlace.Add(place, null);
        }
        countPlace = places.Count - 1;
    }

    public void SetInPlace(Transform fruit)
    {
        for (int i = 0; i <= countPlace; i++) 
        {
            if(fruitPlace[places[countPlace]] != null) basketIsFool = true;
            
            if(fruitPlace[places[i]] == null)
            {
                fruitPlace[places[i]] = fruit;
                fruitPlace[places[i]].SetParent(transform);
                fruitPlace[places[i]].localScale = new Vector3(0.36f, 0.36f, 0.36f);
                fruitPlace[places[i]].position = places[i].position;
                return;
            }
        }
    }

    public int GetCountPlaceInBasket()
    {
        return places.Count;
    }

    public bool BasketIsFool()
    {
        return basketIsFool;
    }
}
