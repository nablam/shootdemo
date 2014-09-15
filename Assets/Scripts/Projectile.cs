﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public float ProjectileSpeed;
    public GameObject ExplosionPrefab;

    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float amtToMove = ProjectileSpeed * Time.deltaTime;
        myTransform.Translate(Vector3.up * amtToMove);
        if (myTransform.position.y > 6.1f)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "enemy")
        {
            Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
            Instantiate(ExplosionPrefab, enemy.transform.position, enemy.transform.rotation);
            enemy.SetPositionAndSpeed();
        
            //Destroy(ExplosionPrefab.transform.GetComponent<ParticleSystem>());
            Destroy(gameObject);
        }
    }
}
