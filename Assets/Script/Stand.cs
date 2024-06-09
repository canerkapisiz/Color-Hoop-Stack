using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject hareketPozsiyonu;
    public GameObject[] soketler;
    public int bosOlanSoket;
    public List<GameObject> cemberler = new();
    [SerializeField] private GameManager gameManager;
    int cemberTamamlanmaSayisi;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public GameObject EnUsttekiCemberiVer()
    {
        return cemberler[^1];
    }

    public void SoketDegistirmeIslemleri(GameObject silinecekObje)
    {
        cemberler.Remove(silinecekObje);
        
        if(cemberler.Count != 0)
        {
            bosOlanSoket--;
            cemberler[^1].GetComponent<Cember>().hareketEdebilirMi = true;
        }
        else
        {
            bosOlanSoket = 0;
        }
    }

    public GameObject MusaitSoketiVer()
    {
        return soketler[bosOlanSoket];
    }

    public void CemberleriKontrolEt()
    {
        if(cemberler.Count == 4)
        {
            string renk = cemberler[0].GetComponent<Cember>().renk;
            foreach (var item in cemberler)
            {
                if(renk == item.GetComponent<Cember>().renk)
                {
                    cemberTamamlanmaSayisi++;
                }
            }

            if (cemberTamamlanmaSayisi == 4)
            {
                gameManager.StandTamamlandi();
                TamamlanmisStandIslemleri();
            }
            else
            {
                cemberTamamlanmaSayisi = 0;
            }
        }
    }

    void TamamlanmisStandIslemleri()
    {
        foreach (var item in cemberler)
        {
            item.GetComponent<Cember>().hareketEdebilirMi = false;
            Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_Color");
            color.a = 150;
            item.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
            gameObject.tag = "tamamlanmisStand";
        }
    }
}
