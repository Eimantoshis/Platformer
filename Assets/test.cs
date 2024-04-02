using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject RegPlayer;
    public GameObject HeavyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HeavyPlayer.gameObject.transform.position = collision.gameObject.transform.position;
            collision.gameObject.SetActive(false);
            HeavyPlayer.gameObject.SetActive(true);
        }
    }
}
