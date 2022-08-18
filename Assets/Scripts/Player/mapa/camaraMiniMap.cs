using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraMiniMap : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.localPosition, 1 * Time.deltaTime);
    }
}
