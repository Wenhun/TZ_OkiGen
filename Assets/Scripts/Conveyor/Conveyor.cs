using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField] ParticleSystem disappearVFX;

    List<Transform> conveyorPlane = new List<Transform>();

    void Awake()
    {
        foreach (Transform child in transform)
        {
            if(child.tag == "Plane") conveyorPlane.Add(child);
        }
    }

    public void GoToStartPosition()
    {
        Transform temp = conveyorPlane[0];
        conveyorPlane.RemoveAt(0);
        conveyorPlane.Add(temp);
        conveyorPlane[conveyorPlane.Count - 1].position = conveyorPlane[conveyorPlane.Count - 2].GetComponent<ConveyorMover>().GetStartPoint();
    }

    void OnDisable()
    {
        Instantiate(disappearVFX, transform.position, Quaternion.identity);
    }
}
