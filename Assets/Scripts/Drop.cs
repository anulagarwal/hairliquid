using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] public EnumsManager.Color color;
    public bool isTransformed;

    private void Start()
    {
        DropManager.Instance.AddDrop(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Drop")
        {
            if(color == EnumsManager.Color.Blue && collision.gameObject.GetComponent<Drop>().color == EnumsManager.Color.Yellow)
            {
                color = EnumsManager.Color.Green;
                gameObject.layer = LayerMask.NameToLayer("Green");
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.GetComponent<Drop>().color == EnumsManager.Color.Blue && color == EnumsManager.Color.Yellow)
            {
                color = EnumsManager.Color.Green;
                gameObject.layer = LayerMask.NameToLayer("Green");
                Destroy(collision.gameObject);

            }
        }
    }
}
