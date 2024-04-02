using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer SR;
    public bool isOn = true;


    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ColorTick()
    {
        Invoke("ToRed", 12);
        Invoke("ToWhite", 12.5f);
        Invoke("ToRed", 13);
        Invoke("ToWhite", 13.5f);
        Invoke("ToRed", 14);
        Invoke("ToWhite", 14.5f);
    }

    private void ToRed()
    {
        SR.color = new Color(255, 0, 0);
    }
    private void ToWhite()
    {
        SR.color = new Color(255, 255, 255);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isOn)
        {
            collision.gameObject.GetComponent<PlayerMovement>().Respawn();
        }
    }
}
