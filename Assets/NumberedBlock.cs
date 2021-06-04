using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberedBlock : MonoBehaviour
{
    [Header ("Components Reference")]
    public int health;
    public bool doesRequireColor;
    public EnumsManager.Color color;

    [Header("Components Reference")]
    public TextMeshPro tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponentInChildren<TextMeshPro>();
        tm.text = "" + health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReduceHealth()
    {
        health--;
        tm.text = "" + health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Drop" && !doesRequireColor)
        {
            ReduceHealth();
            DropManager.Instance.RemoveDrop(collision.gameObject.GetComponent<Drop>());
        }

       else if (collision.gameObject.tag == "Drop" && doesRequireColor && collision.gameObject.GetComponent<Drop>().color == color )
        {
            ReduceHealth();
            DropManager.Instance.RemoveDrop(collision.gameObject.GetComponent<Drop>());
        }
    }
}
