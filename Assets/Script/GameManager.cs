using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject seciliObje;
    GameObject seciliStand;
    Cember cember;
    public bool hareketVar;
    public int hedefStandSayisi;
    int tamamlananStandSayisi;

    public GameObject kazandiPanel;
    public AudioSource[] sesler;

    void Start()
    {
        kazandiPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out RaycastHit hit, 100))
                {
                    if (hit.collider != null && hit.collider.CompareTag("stand"))
                    {
                        if (seciliObje != null && seciliStand != hit.collider.gameObject)
                        {
                            Stand stand = hit.collider.GetComponent<Stand>();

                            if (stand.cemberler.Count != 4 && stand.cemberler.Count != 0)
                            {
                                if (cember.renk == stand.cemberler[^1].GetComponent<Cember>().renk)
                                {
                                    seciliStand.GetComponent<Stand>().SoketDegistirmeIslemleri(seciliObje);

                                    cember.HareketEt("pozisyonDegistir", hit.collider.gameObject, stand.MusaitSoketiVer(), stand.hareketPozsiyonu);
                                    stand.bosOlanSoket++;
                                    stand.cemberler.Add(seciliObje);
                                    stand.CemberleriKontrolEt();
                                    sesler[1].Play();
                                    seciliObje = null;
                                    seciliStand = null;
                                }
                                else
                                {
                                    cember.HareketEt("soketeGeriGit");
                                    sesler[0].Play();
                                    seciliObje = null;
                                    seciliStand = null;
                                }
                            }
                            else if (stand.cemberler.Count == 0)
                            {
                                seciliStand.GetComponent<Stand>().SoketDegistirmeIslemleri(seciliObje);

                                cember.HareketEt("pozisyonDegistir", hit.collider.gameObject, stand.MusaitSoketiVer(), stand.hareketPozsiyonu);
                                stand.bosOlanSoket++;
                                stand.cemberler.Add(seciliObje);
                                stand.CemberleriKontrolEt();
                                sesler[1].Play();
                                seciliObje = null;
                                seciliStand = null;
                            }
                            else
                            {
                                cember.HareketEt("soketeGeriGit");
                                sesler[0].Play();
                                seciliObje = null;
                                seciliStand = null;
                            }
                        }
                        else if (seciliStand == hit.collider.gameObject)
                        {
                            cember.HareketEt("soketeGeriGit");
                            sesler[0].Play();
                            seciliObje = null;
                            seciliStand = null;
                        }
                        else
                        {
                            Stand stand = hit.collider.GetComponent<Stand>();
                            seciliObje = stand.EnUsttekiCemberiVer();
                            cember = seciliObje.GetComponent<Cember>();
                            hareketVar = true;
                            sesler[0].Play();
                            if (cember.hareketEdebilirMi)
                            {
                                cember.HareketEt("secim", null, null, cember.aitOlduguStand.GetComponent<Stand>().hareketPozsiyonu);
                                seciliStand = cember.aitOlduguStand;
                            }
                        }
                    }
                }
            }
        }
    }

    public void StandTamamlandi()
    {
        tamamlananStandSayisi++;
        if(tamamlananStandSayisi == hedefStandSayisi)
        {
            kazandiPanel.SetActive(true);
            PlayerPrefs.SetInt("hangiLevel", SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SonrakiLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
