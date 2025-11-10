using UnityEngine;

public class Bow : MonoBehaviour
{
    public float forceArrow = 10;
    public float destroyTime = 20;
    public float cooldown = 1;
    public float timeSnipe = 0.61f;
    public Arrow prefab;
    public Transform startPosition;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  Time.deltaTime 
        if (Input.GetMouseButtonDown(0))
        {
            // TODO: запуск таймера
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Arrow arrow = Instantiate(prefab, startPosition.position, startPosition.rotation);
        arrow.rb.AddForce(startPosition.up * forceArrow,ForceMode.Impulse);
        Destroy(arrow, destroyTime);
    }

    public void Scope()
    {

    }
}
