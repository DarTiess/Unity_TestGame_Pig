using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        Invoke("DestroyBomb", 3.8f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.gameObject.transform.position -= new Vector3(0.5f, 0f, 0f);
            collision.gameObject.GetComponent<PlayerController>().DeathPig();
            explosionEffect.Play();
            spriteRenderer.enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }


    void DestroyBomb()
    {
        explosionEffect.Play();
        spriteRenderer.enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
