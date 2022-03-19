using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatarangController : MonoBehaviour
{
    public static bool finish;

    public Transform target;
    public float delay;

    public float speed;
    public float forceY;
    public float forceZ;

    private float time;

    void Start()
    {
        finish = false;
        time = 1;
    }

    void Update()
    {
        if (finish)
        {
            time -= Time.deltaTime;

            if(time <= 0)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<Rigidbody>().AddForce(target.position * Time.deltaTime * speed, ForceMode.Impulse);
                gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);

                delay -= Time.deltaTime;

                if(delay <= 0)
                {
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    delay = 0.35f;

                    if(gameObject.transform.GetChild(0).gameObject.activeSelf == true)
                        gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
    }
}
