using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCode : MonoBehaviour
{

    public GameObject ChangeTo;
    public Animator animator;

    private GameObject[] flags;
    public bool IsActive = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        flags = GameObject.FindGameObjectsWithTag("flag");
    }
    public void Active()
    {
       
    }
    public void Passive()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != ChangeTo.gameObject && collision.gameObject.CompareTag("Player"))
        {
           // collision.gameObject.GetComponent<PlayerMovement>().isActive = false;
           // ChangeTo.gameObject.GetComponent<PlayerMovement>().isActive = true;
            ChangeTo.gameObject.transform.position = collision.gameObject.transform.position;
            collision.gameObject.SetActive(false);
            ChangeTo.gameObject.SetActive(true);
            ChangeTo.gameObject.GetComponent<PlayerMovement>().spawn.transform.position = gameObject.transform.position;
            ChangeTo.gameObject.GetComponent<PlayerMovement>().animator.SetTrigger("Change");
            ///Kad sokinejimo animacija nenumustu keitimosi animacijos
            ChangeTo.gameObject.GetComponent<PlayerMovement>().animator.SetBool("IsChanging", true);

            
            
        }else if (collision.gameObject == ChangeTo.gameObject && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().spawn.transform.position = gameObject.transform.position;
        }
        if (collision.gameObject.CompareTag("Player") && !IsActive)
        {
             
            foreach(GameObject flag in flags)
            {
                if (flag.gameObject.GetComponent<FlagCode>().IsActive)
                {
                    flag.gameObject.GetComponent<FlagCode>().IsActive = false;
                    flag.gameObject.GetComponent<FlagCode>().animator.SetBool("IsActive", false);
                    
                }
            }
            IsActive = true;
            animator.SetBool("IsActive", true);
        }

    }
  

}
