using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawOff : MonoBehaviour
{
    public GameObject Saw;

    private float period = 18.15f;
    private float time = 18.15f;

    private SpriteRenderer SR;


    
    // Start is called before the first frame update
    void Start()
    {
         SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && time>period)
        {
            SR.color = new Color(255, 255, 255, 0.4f);
            Saw.gameObject.GetComponent<SawTrap>().isOn = false;
            Saw.gameObject.GetComponent<SawTrap>().ColorTick();
            Saw.gameObject.GetComponent<SawTrap>().animator.SetTrigger("Off");
            Saw.gameObject.GetComponent<SawTrap>().animator.SetBool("IsOff", true);
            Invoke("SawBack", 15f);
            Invoke("MirrorBack", 18.15f);
           // Saw.gameObject.GetComponent<SawTrap>().animator.set
            time = 0;
        }
    }
    private void SawBack()
    {
        Saw.gameObject.GetComponent<SawTrap>().animator.SetBool("Mirror", true);
        Saw.gameObject.GetComponent<SawTrap>().animator.SetBool("IsOff", false);
    }
    private void MirrorBack()
    {
        Saw.gameObject.GetComponent<SawTrap>().animator.SetBool("Mirror", false);
        Saw.gameObject.GetComponent<SawTrap>().isOn = true;
        SR.color = new Color(255, 255, 255, 1f);
    }
   

}
