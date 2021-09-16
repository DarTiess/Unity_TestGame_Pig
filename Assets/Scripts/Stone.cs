using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    SpriteRenderer spriteRenderer;
    public GameObject foodPref;
    public GameObject bombPref;
    // Start is called before the first frame update
    void Start()
    {
        foodPref.SetActive(false);
        bombPref.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int rnd = Random.Range(0, 4);
            Debug.Log("trigger stone");
            collision.gameObject.transform.position -= new Vector3(0.8f, 0f, 0f);
            explosionEffect.Play();
          //  spriteRenderer.enabled = false;
         //   gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
         //  ChooseInside(rnd);
           
        }
    }

    void ChooseInside(int i)
    {
        switch (i)
        {
            case 0:
                foodPref.SetActive(true);
                break;
            case 1:
                bombPref.SetActive(true);
                break;
            case 2:
                foodPref.SetActive(true);
                break;
            case 3:
                bombPref.SetActive(true);
                break;
        }
    }
}
