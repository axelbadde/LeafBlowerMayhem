using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
     if (col.gameObject.tag.Equals("Bullet")) 
        {
            ScoreScript.scoreValue += 10;
            Destroy(col.gameObject);
            Destroy(gameObject);

        
        }
            

    }

}


