using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cember : MonoBehaviour
{
    public GameObject aitOlduguStand;
    public GameObject aitOlduguCemberSoketi;
    public bool hareketEdebilirMi;
    public string renk;
    public GameManager gameManager;

    GameObject hareketPozsiyonu;
    GameObject gidecegiStand;

    bool secildi, posDegistir, soketOtur, soketeGeriGit;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (secildi)
        {
            transform.position = Vector3.Lerp(transform.position, hareketPozsiyonu.transform.position, .2f);
            if(Vector3.Distance(transform.position,hareketPozsiyonu.transform.position) < .10)
            {
                secildi = false;
            }
        }

        if (posDegistir)
        {
            transform.position = Vector3.Lerp(transform.position, hareketPozsiyonu.transform.position, .2f);
            if (Vector3.Distance(transform.position, hareketPozsiyonu.transform.position) < .10)
            {
                posDegistir = false;
                soketOtur = true;
            }
        }

        if(soketOtur)
        {
            transform.position = Vector3.Lerp(transform.position, aitOlduguCemberSoketi.transform.position, .2f);
            if (Vector3.Distance(transform.position, aitOlduguCemberSoketi.transform.position) < .10)
            {
                transform.position = aitOlduguCemberSoketi.transform.position;
                soketOtur = false;

                aitOlduguStand = gidecegiStand;

                if(aitOlduguStand.GetComponent<Stand>().cemberler.Count > 1)
                {
                    aitOlduguStand.GetComponent<Stand>().cemberler[^2].GetComponent<Cember>().hareketEdebilirMi = true;
                }
                gameManager.hareketVar = false;
            }
        }

        if (soketeGeriGit)
        {
            transform.position = Vector3.Lerp(transform.position, aitOlduguCemberSoketi.transform.position, .2f);
            if (Vector3.Distance(transform.position, aitOlduguCemberSoketi.transform.position) < .10)
            {
                transform.position = aitOlduguCemberSoketi.transform.position;
                soketeGeriGit = false;
                gameManager.hareketVar = false;
            }
        }
    }

    public void HareketEt(string islem, GameObject stand= null, GameObject soket = null, GameObject gidilecekObje = null)
    {
        switch (islem){
            case "secim":
                hareketPozsiyonu = gidilecekObje;
                secildi = true;
                break;
            case "pozisyonDegistir":
                gidecegiStand = stand;
                aitOlduguCemberSoketi = soket;
                hareketPozsiyonu = gidilecekObje;
                posDegistir = true;
                break;
            case "soketeGeriGit":
                soketeGeriGit = true;
                break;
        }
    }
}
