using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    float t = 0;
    public float speed;
    public float minRange;
    public float maxRange;
    // Start is called before the first frame update
    void Start()
    {
        this.Init();
        //Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
        t += Time.deltaTime;
        if (t > 5f) {
            t = 0;
            this.Init();
        }
    }
    public void Init()
    {
        float y = Random.Range(minRange, maxRange);
        this.transform.localPosition = new Vector3(0, y, 0);
    }
    

}
