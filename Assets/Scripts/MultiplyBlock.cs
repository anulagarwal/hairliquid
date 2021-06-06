using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplyBlock : MonoBehaviour
{

    [Header("Components Reference")]
    public int multiplier;
    public bool doesRequireColor;
    public EnumsManager.Color color;

    [Header("Components Reference")]
    public GameObject drop;
    public Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = "x" + multiplier;
    }

    public void MultiplyDrops(Vector3 pos, Drop d)
    {
        int i = 0;
        while (i <= multiplier)
        {
           GameObject g = Instantiate(drop, pos, Quaternion.identity);
            g.layer = d.gameObject.layer;
            g.GetComponent<SpriteRenderer>().color = d.GetComponent<SpriteRenderer>().color;
            DropManager.Instance.AddDrop(g.GetComponent<Drop>());
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Drop" && !doesRequireColor && !collision.gameObject.GetComponent<Drop>().isTransformed)
        {
            MultiplyDrops(collision.transform.position, collision.GetComponent<Drop>());            
            collision.gameObject.GetComponent<Drop>().isTransformed = true;
            DropManager.Instance.RemoveDrop(collision.gameObject.GetComponent<Drop>());

        }

        else if (collision.gameObject.tag == "Drop" && doesRequireColor && collision.gameObject.GetComponent<Drop>().color == color && !collision.gameObject.GetComponent<Drop>().isTransformed)
        {
            collision.gameObject.GetComponent<Drop>().isTransformed = true;
            MultiplyDrops(collision.transform.position, collision.GetComponent<Drop>());
            DropManager.Instance.RemoveDrop(collision.gameObject.GetComponent<Drop>());

        }
    }
    
}
