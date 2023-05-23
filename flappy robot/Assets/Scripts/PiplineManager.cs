using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiplineManager : MonoBehaviour
{
    public GameObject template;
    List<Pipeline> pipelines = new List<Pipeline>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine = null;
    public void Init() {
        for (int i = 0; i < pipelines.Count; i++) { 
            Destroy(pipelines[i].gameObject);
        }
        pipelines.Clear();
    }

    public void StartRun() {
            coroutine = StartCoroutine(GeneratePiplines());
    }

    public void StopRun()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < pipelines.Count; i++)
            pipelines[i].enabled = false;
    }

    IEnumerator GeneratePiplines() {
        for(int i=0;i<=4;i++){
            if (pipelines.Count <= 4)
                CreatePipeline();
            else {
                pipelines[i].enabled = true;
                pipelines[i].Init();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void CreatePipeline() {
        if (pipelines.Count <= 4) { 
            GameObject obj=Instantiate(template, this.transform);
            Pipeline p = obj.GetComponent<Pipeline>();
            pipelines.Add(p);
        }
    }
}
