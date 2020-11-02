using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        transform.Translate(new Vector3(0,0,1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
