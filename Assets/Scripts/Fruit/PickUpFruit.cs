using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PickUpFruit : MonoBehaviour
{
    [SerializeField] Transform hand;
    [SerializeField] ChainIKConstraint chainIKConstraint;
    [SerializeField] PlacerInBasket placerInBasket;
    [SerializeField] ScoreChecker scoreChecker;
    [SerializeField] PlusOneText plusOneText;

    Transform pickUpFruit;
    RigBuilder rigBuilder;

    void Start()
    {
        rigBuilder = GetComponent<RigBuilder>();
    }

    public void SetPickUpFruit(Transform fruit)
    {
        pickUpFruit = fruit;
        chainIKConstraint.data.target = fruit.transform;
        rigBuilder.Build();
    }

    public void HandStop()
    {
        chainIKConstraint.data.target = null;
        rigBuilder.Build();
    }

    //animator method
    public void PickUp()
    {
        if (pickUpFruit != null)
        {
            pickUpFruit.SetParent(hand);
            pickUpFruit.position = hand.position;
            pickUpFruit.GetComponent<Rigidbody>().detectCollisions = false;
            pickUpFruit.GetComponent<Rigidbody>().isKinematic = true;
            HandStop();
        }
    }

    //animator method
    public void PutIn()
    {
        placerInBasket.SetInPlace(pickUpFruit);
        scoreChecker.GameStatusCheck(pickUpFruit.GetComponent<Fruit>().fruitName);
        plusOneText.gameObject.SetActive(true);
        pickUpFruit = null;
    }
}