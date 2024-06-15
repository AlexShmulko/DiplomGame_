using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    DataManager dataManager;

    public int a = 0;

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
        if (rb!= null)
        {
            Debug.Log("blyaat");
            rb.AddForce(-fp.transform.right.x * new Vector2(80f, -30f));

            if(fp.transform.right.x == 1){
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
