using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kontrol : MonoBehaviour

{

    public Sprite[] KusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kusAnimasyonZaman = 0;

    Rigidbody2D fizik;
    int puan = 0;
    public Text puanText;

    bool oyunBitti = true;
    OyunKontrol oyunKontrol;
    AudioSource[] sesler;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("OyunKontrol").GetComponent<OyunKontrol>();
        sesler = GetComponents<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && oyunBitti) {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 200));
            sesler[0].Play();

        }
        if (fizik.velocity.y > 0) {
            transform.eulerAngles = new Vector3(0, 0, 30);
        }
        else {
            transform.eulerAngles = new Vector3(0, 0, -30);
        }
        Animasyon();

       
    }


    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.1f)
        {
            kusAnimasyonZaman = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Puan")
        {
            puan++;
            puanText.text = "Score = " + puan;
            sesler[1].Play();

        }

        if (col.gameObject.tag == "Engel")
        {
            oyunBitti = false;
            oyunKontrol.oyunBitti();
            sesler[2].Play();
            GetComponent<CircleCollider2D>().enabled = false;
        }

    }





    
}












