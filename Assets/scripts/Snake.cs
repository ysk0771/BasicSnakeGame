using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    [HideInInspector]
    Vector2 dir = Vector2.right;
    bool ate = false;
    public GameObject tailPrefab;
    [HideInInspector]
    public string direction="right";
    List<Transform> tail = new List<Transform>();
    //public Transform bordertop, borderBottom, borderLeft, borderRight;
    public RectTransform panel;
    public Text gameOverText;
    public static Text  score;
    public GameObject TextScore;
    [HideInInspector]
    public int Sayi;
     public AudioClip sound;
    AudioSource ASource;
    public Camera mainCamera;
    
    void Start()
    {
        Sayi = 0;
        score = TextScore.GetComponent<Text>();
        InvokeRepeating("Move", 1.5f, 0.3f);
        ASource= GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       // hareketpc();

        
       
           
        
        
        
    }
    public void RightButton()
    {
        if (direction != "left")
        {
            dir = Vector2.right;
            direction = "right";
        }

    }

    public void LeftButton()
    {
        if (direction != "right")
        {
            dir = -Vector2.right;
            direction = "left";
        }
    }

    public void UpButton()
    {
        if (direction != "down")
        {
            dir = Vector2.up;
            direction = "up";
        }
    }

    public void DownButton()
    {
        if (direction != "up")
        {
            dir = -Vector2.up;
            direction = "down";
        }
    }

    void hareketpc()
    {
        //Burdaki if'lerin kullanımı ile yılanımıza yön verirken kendiyle çarpışmasını önledik
        //2.ci if ile olası 2 tuş basımındaki bugu önledik

        if ((Input.GetKeyDown(KeyCode.RightArrow)) && direction != "left")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                dir = Vector2.right;
            }
            dir = Vector2.right;
            direction = "right";
        }       
        
            if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != "right")
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    dir = -Vector2.right;
                }
                dir = -Vector2.right;
                direction = "left";

            }
        if (Input.GetKeyDown(KeyCode.DownArrow) && direction != "up")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                dir = -Vector2.up;
            }
            dir = -Vector2.up;
            direction = "down";

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != "down")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                dir = Vector2.up;
            }
            dir = Vector2.up;
            direction = "up";
        }


    }
    void Move()
    {

        // Güncel pozisyonu kaydeder
        Vector2 v = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(dir);

        // Ate something? Then insert new Element into gap
        if (ate)
        {
            //Yeme efektini her yediğinde bir kere çalmasını sağlar
            ASource.PlayOneShot(sound,0.7f);
                        //sayi değişkeninde score değerini tutuyoruz
            Sayi++;
            //start fonksiyonunda score text objesine eşitlendi ve text erişip skoru düzenliyoruz
            score.text = "Score:" + Sayi;
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab,
                                                  v,
                                                  Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            
            // Reset the flag
            ate = false;
        }

        // Ne kadar Kuyruğa sahibiz kontrolü
        if (tail.Count > 0)
        {
            // son kuyruk parçasının posisyonunu değişkene atıyoruz
            tail.Last().position = v;

            // Kuyruğu headin yani yılanımız kafası olarak atadığımız <liste>değişkenin arkasına ekliyor ve arkadakini siliyoruz
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("food"))
        {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        else
        {
           
           SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

            
            

            // ToDo 'You lose' screen
        }
    }
}
    
