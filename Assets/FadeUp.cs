using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FadeUp : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float destroyDelay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        GetComponentInChildren<TextMeshPro>().alpha -= fadeSpeed;
    }
}
