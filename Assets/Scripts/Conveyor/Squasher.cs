using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squasher : MonoBehaviour
{
    [SerializeField] Button squashButton;
    [SerializeField] float speedUp = 2f;
    bool squashOff = false;

    Rigidbody rb;
    Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    public void Squash()
    {
        rb.useGravity = true;
        squashButton.interactable = false;
    }

    void Update()
    {
        if(squashOff)
        {
            Vector3 pos = transform.position + Vector3.up * Time.deltaTime * speedUp;
            rb.MovePosition(pos);
            rb.useGravity = false;
            if(transform.position.y >= startPosition.y)
            {
                squashOff = false;
                rb.velocity = new Vector3(0, 0, 0);
                transform.position = startPosition;
                squashButton.interactable = true;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Fruit" || other.gameObject.tag == "Rotten")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Plane")
        {
            squashOff = true;
        }
    }
}
