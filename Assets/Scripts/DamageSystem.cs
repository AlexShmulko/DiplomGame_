using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    DataManager dataManager;

    public int a = 0;

    public float forceX = 5f;
    public float forceY = -15f;

    public Transform fp;

    public bool isDamageTaken = false;

    public Rigidbody2D rb;

    public DataManager DataManager
    {
        get => default;
        set
        {
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dataManager = DataManager.Instance;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        a = dataManager.GetDamage();
        Debug.Log(a);
        if (a > 0)
        {
            ForceHero();
        }
    }

    public void ForceHero()
    {
        if (rb != null)
        {
            // Обнуление текущей скорости по оси X для предотвращения сильного отбрасывания
            rb.velocity = new Vector2(0, rb.velocity.y);

            Debug.Log("blyaat");
            rb.AddForce(new Vector2(-fp.transform.right.x * forceX, forceY), ForceMode2D.Impulse);

            if (fp.transform.right.x == 1)
            {
                Debug.Log("tratra");
            }
        }
    }

    public void TimerKek()
    {
        a = 0;
        dataManager.SetDamage(a);
    }

    public void SecretInvoke()
    {
        Invoke("TimerKek", 0.3f);
    }
}