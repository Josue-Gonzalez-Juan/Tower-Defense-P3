using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Reflection;

public class Raycast : MonoBehaviour
{
    public float rayLength;
    
    public int damage;

    private PurseManager myPurse;

    public GameObject tower;
    
    public Transform towerParent;

    void Start()
    {
        myPurse = GameObject.FindGameObjectWithTag("Purse").GetComponent<PurseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000f, Color.red);
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                print(hit.collider.gameObject.transform.parent.gameObject.name);
                if (hit.collider.gameObject.transform.parent.tag == "Enemy")
                {
                    hit.collider.gameObject.transform.parent.gameObject.GetComponent<Enemy>().takeDamage(damage);
                }
                if (hit.collider.tag == "TowerLocation")
                {
                    if (myPurse.PlaceTower(200))
                    {
                        Instantiate(tower, hit.transform.position, Quaternion.identity, towerParent);
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                print("hit nothing");
            }
        }
    }
}
