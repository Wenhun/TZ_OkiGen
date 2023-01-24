using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorReturner : MonoBehaviour
{
    [SerializeField] Conveyor conveyor;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plane") conveyor.GoToStartPosition();
    }

}
