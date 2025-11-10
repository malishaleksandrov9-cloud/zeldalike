using Neo.Extensions;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Camera camera;
    
    [Header("Settings")]
    public float forceArrow = 10;
    public float destroyTime = 20;
    public float cooldown = 1;
    public float timeSnipe = 0.61f;

    [Header("Camera")] 
    public float speedChangeFow = 10;
    public float startFow = 60;
    public float endFow = 50;
    
    [Header("Arrow")]
    public Arrow prefab;
    public Transform startPosition;

    private bool isReadyShoot = true;
    private Arrow spawnArrown;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //  Time.deltaTime 
        if (Input.GetMouseButtonDown(0))
        {
            // TODO: ������ �������
        }

        if (isReadyShoot && spawnArrown == null)
        {
            spawnArrown = Instantiate(prefab, startPosition.position, startPosition.rotation, transform);
            spawnArrown.rb.isKinematic = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (isReadyShoot)
            {
                camera.fieldOfView = Mathf.Max(camera.fieldOfView + (speedChangeFow * Time.deltaTime), endFow);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isReadyShoot)
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        spawnArrown.transform.SetParent(null);
        spawnArrown.rb.isKinematic = false;
        spawnArrown.rb.AddForce(startPosition.up * forceArrow, ForceMode.Impulse);
        Destroy(spawnArrown, destroyTime);
        isReadyShoot = false;
        camera.fieldOfView = startFow;
        this.Delay(cooldown, ReadyShoot);
        spawnArrown = null;
    }

    public void ReadyShoot()
    {
        isReadyShoot = true;
    }

    public void Scope()
    {
    }
}