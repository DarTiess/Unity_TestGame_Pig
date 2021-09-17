using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dog : MonoBehaviour
{
    public float speed;
    public ParticleSystem explosionEffect;
    public Sprite dirtSprite;
    public Sprite angrySprite;
    SpriteRenderer spriteRenderer;
    Sequence mySequence;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveX(-13.42f, speed)).OnComplete(DestroyDog);
     
    }

    // Update is called once per frame
    void Update()
    {



    }

    void DestroyDog()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            mySequence.Kill();
            explosionEffect.Play();
            spriteRenderer.sprite = dirtSprite;
            StartCoroutine(AngryDog());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
           
            mySequence.Kill();
            explosionEffect.Play();
            spriteRenderer.sprite = angrySprite;
            collision.gameObject.GetComponent<PlayerController>().DeathPig();
        }
    }

    
    IEnumerator AngryDog()
    {
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = angrySprite;
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveX(-13.42f, speed)).OnComplete(DestroyDog);
    }


}
