using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit[] raycastHit = Physics.RaycastAll(raycast);
            foreach (RaycastHit hit in raycastHit)
            {
                if (hit.collider.tag == "Fruit")
                {
                    if(!hit.collider.GetComponent<Fruit>().clicked)
                    {
                        hit.collider.GetComponent<Fruit>().clicked = true;
                    }
                    else
                    {
                        hit.collider.GetComponent<Fruit>().clicked = false;
                    }
                }
            }
        }
    }

}
