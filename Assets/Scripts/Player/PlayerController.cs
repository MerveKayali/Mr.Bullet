using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed = 100, bulletSpeed = 100; //döndürme ve mermi hýzlarý

    private Transform handPos,firePos1,firePos2;
    public int ammo=4;
    private LineRenderer laser;
    public GameObject bullet;

    private GameObject crosshair;

    public AudioClip gunShot;
    void Awake()
    {
        crosshair = GameObject.Find("crosshair");
        crosshair.SetActive(false);
        handPos = GameObject.Find("/Player/LeftArm").transform;
        firePos1 = GameObject.Find("FirePosition1").transform;
        firePos2 = GameObject.Find("FirePosition2").transform;
        laser = GameObject.Find("Gun").GetComponent<LineRenderer>();
        laser.enabled = false;

      
    }

   
    void Update()
    {
        if(!IsMouseOverUI())//Restart butonu veya exit butonuna basarken niþan alma iþlemini iptal etmek için kontrol ediyoruz eðer butonlara basmýyorsa niþan alýp ateþ edecek
        {
            if (Input.GetMouseButton(0))
            {
                Aim();//ekrana basýlý tutuyorsak fareyi niþan al
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (ammo > 0)
                    Shoot();//ekrandan çekiyorsak ateþ et
                else
                    laser.enabled = false;
                    crosshair.SetActive(false);
            }

        }
       
    }

    void Aim()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - handPos.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        handPos.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.fixedDeltaTime);

        laser.enabled = true;
        laser.SetPosition(0, firePos1.position);
        laser.SetPosition(1, firePos2.position);
        crosshair.SetActive(true);
        crosshair.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3.forward * 10);



    }

    void Shoot()
    {
        crosshair.SetActive(false);
        GameObject b = Instantiate(bullet, firePos1.position, Quaternion.identity);

        if (transform.localScale.x > 0)
            b.GetComponent<Rigidbody2D>().AddForce(firePos1.right * bulletSpeed, ForceMode2D.Impulse);
        else
            b.GetComponent<Rigidbody2D>().AddForce(-firePos1.right * bulletSpeed, ForceMode2D.Impulse);
        ammo--;

        FindObjectOfType<GameManager>().CheckBullet();
        SoundManager.instance.PlaySoundFX(gunShot, 0.3f);
        Destroy(b, 2);

      

    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();//Restart butonu veya exit butonuna basarken niþan alma iþlemini iptal etmek için kontrol ediyoruz
    }
    
}
