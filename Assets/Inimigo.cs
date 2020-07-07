using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector3 target;
    private float speed = 1;
    private Vector3 positionOld = new Vector3();
    private static bool primeiro = true;
    
    void Start()
    {
        target = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
        
        if (primeiro) 
        {
            primeiro = false;
            for (int i = 0; i < 10; i++)
            {
                Vector3 posicao = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
                GameObject outro = Instantiate(gameObject, transform.position, transform.rotation) as GameObject; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        positionOld = transform.position;
        
        float dist = Vector3.Distance(transform.position, target);
        if (dist <= 0.1)
        {
            target = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
        }   
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        transform.position = positionOld;
        target = target * -1;
        target = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
    }
    
    void OnTriggerEnter()
    {
        if (outro.gameObject.CompareTag("tiro"))
        {
            Destry(gameObject);
        }    
    }
}
