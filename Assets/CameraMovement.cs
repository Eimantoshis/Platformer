using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (target1.gameObject.GetComponent<PlayerMovement>().isActive)
        {
            transform.position = new Vector3(target1.transform.position.x, 0, -10);
        }
        if (target2.gameObject.GetComponent<PlayerMovement>().isActive)
        {
            transform.position = new Vector3(target2.transform.position.x, 0, -10);
        }
        if (target3.gameObject.GetComponent<PlayerMovement>().isActive)
        {
            transform.position = new Vector3(target3.transform.position.x, 0, -10);
        }*/
        if (target1.gameObject.activeSelf)
        {
            transform.position = new Vector3(target1.transform.position.x, 0, -10);
        }
        if (target2.gameObject.activeSelf)
        {
            transform.position = new Vector3(target2.transform.position.x, 0, -10);
        }
        if (target3.gameObject.activeSelf)
        {
            transform.position = new Vector3(target3.transform.position.x, 0, -10);
        }
    }
}
