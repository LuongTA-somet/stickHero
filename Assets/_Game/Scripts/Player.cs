using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
   private bool flag = false;
    private void Update()
    {
        if (!flag&&GameManager.Instance.bossTime==true)
        {
            ChangeAnim("Sword");
            flag = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(EnemyImpact());
        }
        
    }
    public    IEnumerator EnemyImpact()
    {  
        ChangeAnim("Sword");
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
