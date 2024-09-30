using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Transform[] spawnPos; 
  public float speed=5f;
    private bool fingerDown = false;
    private Vector3 startMousePos;
    private Vector3 endMousePos;
    public float score = 7;
    public bool flag=false;
    public GameObject holder;
    public GameObject prefab;

    public Text scoreTxt;
  
    private void Start()
    {
       
    }
    void Update()
    {
       if(scoreTxt != null) scoreTxt.text=score.ToString();
        
            Move();
       
      
    }
    public void Move() {

        gameObject.transform.position += new Vector3(0, 0, speed);
        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
          
            startMousePos = Input.mousePosition;
            fingerDown = true;
        }
        if (fingerDown)
        {

            if (Input.mousePosition.x > startMousePos.x)
            {
                transform.position += new Vector3(0.2f, 0, 0);
                if (transform.position.x >= 10f)
                {
                    transform.position = new Vector3(10f, 0, transform.position.z);
                }
            }
            if (Input.mousePosition.x < startMousePos.x)
            {
                gameObject.transform.position += new Vector3(-0.2f, 0, 0);
                if (transform.position.x <= -10f)
                {
                    transform.position = new Vector3(-10f, 0, transform.position.z);
                }
            }
        }
        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate")==true)
        {
            score *= 10;
            Debug.Log("Gate hit");
            if (!flag) {
                SpawnPlayer(50);
                flag = true;
            }
           
        }
        if (other.CompareTag("Enemy"))
        {
            speed = 0.05f;
        }
        if (other.CompareTag("Pass"))
        {
            speed = 0.2f;
        }
        if (other.CompareTag("Boss"))
        {
            speed = 0f;
            GameManager.Instance.bossTime=true;
        }
    }

public void SpawnPlayer(int times)
    {
        for (int i = 0; i < times; i++)
        {
            GameObject spawnedPrefab = Instantiate(prefab, spawnPos[i%6].position, Quaternion.identity);
            spawnedPrefab.transform.SetParent(holder.transform);
        }
      
    }




}


