using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
   // public Transform target;
    //public float speed = 0.1f;
    private void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          //  transform.position = Vector3.Lerp(transform.position, transform.parent.position, 2);
            StartCoroutine(PlayerImpact());
        }
    }
    public IEnumerator PlayerImpact()
    {

        ChangeAnim("Sword");
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
