using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character
{
    public bool flag=false;
    private void Update()
    {
        if (!flag && GameManager.Instance.bossTime==true)
        {
            ChangeAnim("Attack");
            flag = true;
        }
    }
}
