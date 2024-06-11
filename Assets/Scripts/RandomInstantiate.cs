using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomInstantiate : MonoBehaviour
{
    public GameObject prefab;
    public float interval;
    private GameObject parent;
    public bool On;
    void Start()
    {
        StartCoroutine(generateObject());
    }

    IEnumerator generateObject()
    {
        while (true)
        {
            if (On)
            {
                parent = Instantiate(prefab, new Vector3(this.transform.position.x + Random.Range(-0.1f, 0.1f), this.transform.position.y, this.transform.position.z + Random.Range(-0.1f, 0.1f)), Quaternion.identity);
                parent.transform.parent = this.transform;
            }

                yield return new WaitForSeconds(interval);
            

        }

    }
}
