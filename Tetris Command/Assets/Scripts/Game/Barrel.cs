using UnityEngine;
using System.Collections;
using static CoroutineHelper;
using UnityEngine.UI;

public class Barrel : MonoBehaviour
{
    Camera mainCam;
    new Transform transform;
    bool canShoot;
    [SerializeField] GameObject[] bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] int mouseButtonToFire;
    public int firingMode; // 1 is destroy, 2 is move right, 3 is move left, 4 is rotate 
    [SerializeField] Slider cooldownSlider;

    const float CooldownTime = 1.5f;
    float currentCooldownTime;

    [SerializeField] FiringIcons icons;

    void Awake()
    {
        mainCam = Camera.main;
        transform = GetComponent<Transform>();
        canShoot = true;
        firingMode = 1;

        FindObjectOfType<PauseHandler>().PauseAction += OnPauseStateChanged;
        FindObjectOfType<GameOverHandler>().GameOverAction += OnGameOver;
    }

    void Update()
    {
        Vector3 target = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(-difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(mouseButtonToFire) && canShoot)
        {
            canShoot = false;
            StartCoroutine(Shoot());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            firingMode = 1;
            icons.UpdateIcons(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && mouseButtonToFire == 0)
        {
            firingMode = 2;
            icons.UpdateIcons(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && mouseButtonToFire == 1)
        {
            firingMode = 3;
            icons.UpdateIcons(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            firingMode = 4;
            icons.UpdateIcons(2);
        }



        /*   FOR ROTATING THE OTHER WAY WHEN USING THE OTHER BARREL
         * else if (Input.GetKeyDown(KeyCode.Alpha3) && mouseButtonToFire ==1)
        {
            firingMode = 5;            
        }
         */

    }

    IEnumerator Shoot()
    {
        Instantiate(bulletPrefab[firingMode - 1], bulletSpawnPos.position, transform.rotation);
        while (currentCooldownTime < CooldownTime)
        {
            yield return EndOfFrame;
            currentCooldownTime += Time.deltaTime;
            cooldownSlider.value = currentCooldownTime / CooldownTime;
        }

        canShoot = true;

        //reset values
        currentCooldownTime = 0;
        cooldownSlider.value = 1f;
    }

    void OnPauseStateChanged(bool state)
    {
        enabled = !state;
    }

    void OnGameOver()
    {
        enabled = false;
    }
}