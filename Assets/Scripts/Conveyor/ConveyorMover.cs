using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMover : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] float conveyorSpeed = 0.5f;

    public Vector3 GetStartPoint()
    {
        return start.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position + Vector3.right * conveyorSpeed * Time.fixedDeltaTime;
        gameObject.GetComponent<Rigidbody>().MovePosition(pos);
    }
}
