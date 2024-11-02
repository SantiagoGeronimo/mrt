using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWallBehavior : MonoBehaviour
{
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.isDashing)
        {
            coll.enabled = false;
        } else
        {
            coll.enabled = true;
        }
    }


    //Deberia poder resolverlo de esta manera alguna vez, probe cambiando con el stay en vez de enter y funcionaba pero con un leve delay
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("entro juas juas");
            var go = collision.gameObject.GetComponent<PlayerMovement>();
            if (go != null && go.isDashing)
            {
                Debug.Log(go.isDashing);

                coll.enabled = false;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        coll.enabled = true;
    }*/
}
