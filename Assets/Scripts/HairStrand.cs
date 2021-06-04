using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairStrand : MonoBehaviour
{
    [SerializeField] private float alphaIncrease;
    [SerializeField] private EnumsManager.Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Drop")
        {
            if (collision.gameObject.GetComponent<Drop>().color == color)
            {
                DropManager.Instance.CompleteStrand(this);
            }
            else
            {
                DropManager.Instance.IncorrectStrand(this);
            }
            GetComponentInChildren<MeshRenderer>().material.color = collision.transform.GetComponent<SpriteRenderer>().color;
            GetComponent<BoxCollider2D>().enabled = false;
            UIManager.Instance.SpawnAwesomeText(collision.gameObject.transform.position, "+1");

            DropManager.Instance.RemoveDrop(collision.gameObject.GetComponent<Drop>());

        }
    }
}
