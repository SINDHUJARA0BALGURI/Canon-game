using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float bulletSpeed = 500;
    public GameObject bullet;

    AudioSource bulletAudio;

    List<GameObject> bulletList;



    // Start is called before the first frame update
    void Start()
    {
        bulletList = new List<GameObject>();
        for(int i = 0; i < 10; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
        bulletAudio = GetComponent<AudioSource>();
    }

    void Fire()
    {
     for(int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position=transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                Rigidbody rb = bulletList[i].GetComponent<Rigidbody>();
                GetComponent<AudioSource>().Play();
                rb.AddForce(rb.transform.forward * bulletSpeed);
                break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }




    }
}
