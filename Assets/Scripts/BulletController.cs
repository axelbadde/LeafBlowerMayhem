using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField]

    private float speed = 4f;

    IEnumerator DestroyBulletAfterTime() 
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBulletAfterTime());  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World); 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

}
