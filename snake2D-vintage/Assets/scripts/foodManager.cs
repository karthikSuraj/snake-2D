using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodManager : MonoBehaviour
{
    
    private  bool canSpwanFood = true;
    public int respwantime = 5;
    public string nameOFTheFood;
    public int PickUpPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpwanFood)
            StartCoroutine(foodSpwaner());
    }
 
    IEnumerator foodSpwaner()
    {
        canSpwanFood = false;
        yield return new WaitForSeconds(respwantime);
        transform.position= new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-4.5f, 4.27f), 0);
        canSpwanFood = true;
    }
}
