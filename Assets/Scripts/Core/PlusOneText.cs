using UnityEngine;
using System.Collections;

public class PlusOneText : MonoBehaviour
{
    Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;    
    }

    void OnEnable()
    {
        transform.position = startPosition;
        StartCoroutine(Disable());
    }
    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
