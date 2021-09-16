using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Farmer : MonoBehaviour
{
   
    public float speed;
    public Vector3[] waypoints = new[] {
        new Vector3(0, 0, 0),
        new Vector3(0,0, 0),
        new Vector3(0, 0, 14),
        new Vector3(0, 6, 6),
        new Vector3(-3, 0, 0),
        new Vector3(-3, 0, 0)
    };
   
    public Sprite spriteDown;
    public Sprite spriteUp;
    public Sprite spriteLeft;
    public Sprite spriteRight;
    public Sprite dirtSprite;
    public SpriteRenderer spriteRenderer;
    public GameObject bobmPref;
   
    // Start is called before the first frame update
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(waypoints[0], speed).OnComplete(ReturnDown));
        mySequence.Append(transform.DOMove(waypoints[1], speed).OnComplete(ReturnLeft));
        mySequence.Append(transform.DOMove(waypoints[2], speed).OnComplete(ReturnUp));
        mySequence.Append(transform.DOMove(waypoints[3], speed).OnComplete(ReturnRight));
        mySequence.SetLoops(-1);

        InvokeRepeating("MakeBomb", 1f, 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
      


    }
    void MakeBomb()
    {
        Instantiate(bobmPref, transform.position, bobmPref.transform.rotation);
    }
    void ReturnDown()
    {
        spriteRenderer.sprite = spriteDown;
    }
    void ReturnLeft()
    {
        spriteRenderer.sprite = spriteLeft;
    } 
    void ReturnRight()
    {
        spriteRenderer.sprite = spriteRight;
    } void ReturnUp()
    {
        spriteRenderer.sprite = spriteUp;
    }

   
}
