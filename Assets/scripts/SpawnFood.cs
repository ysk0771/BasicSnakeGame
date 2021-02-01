using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    //Tanimlamaca Yiyecek Prefabı
    public GameObject Prefabfood;

    //Tanimlanacak Katmanlar
    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;
    void Start()
    {
        //4 saniyede 4 tane yiyecek oluşturur.
        InvokeRepeating("Spawn", 4, 4);
    }

  void Spawn()
    {
        //x kordinatının sınırları belirlendi
        int x = (int)Random.Range(BorderLeft.position.x, BorderRight.position.x);
        //y kordinatının sınırları belirlendi
        int y = (int)Random.Range(BorderTop.position.y, BorderBottom.position.y);
        //İnstantiate ile oluşturulacak yiyeceğin (x,y) oluşturulur
        Instantiate(Prefabfood, new Vector2(x, y), Quaternion.identity); //Quarnetion Varsayılan pozisyon
    }
   
}
