using System.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class FruitPickUpZone : MonoBehaviour
{
    [SerializeField] Animator animator;

    //If fruit in PickUp Zone
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Fruit" && other.GetComponent<Fruit>().clicked)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PickUp"))
            {
                other.GetComponent<Fruit>().clicked = false;
                animator.GetComponent<PickUpFruit>().SetPickUpFruit(other.transform);
                animator.SetTrigger("PickUp");
            }
        }
    }

    //If fruit exit PickUp Zone
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fruit")
        {
            other.GetComponent<Fruit>().clicked = false;
            animator.GetComponent<PickUpFruit>().HandStop();
        }
    }
}