using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    [SerializeField] GameObject sampleCubePrefab;
    [SerializeField] float maxScale = 1000f;
    private GameObject[] sampleCubeArray = new GameObject[512];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sampleCubeArray.Length; i++)
        {
            GameObject instanceSampleCube = (GameObject)Instantiate(sampleCubePrefab);
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "Sample Cube " + i + 1;

            // 360 / 512 = 0.703125 (We divide 360 degrees by 512 samples so that we know
            // how far we should move each instance)
            // Что зздесь происходит: Этот объект спавнит 512 кубов, каждую итерацию этот
            // объект поворачивается на 0.703125 градусов. Кубы спавнятся на расстоянии
            // 100 от этого объекта в направлении Vector3.forward
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 100;

            sampleCubeArray[i] = instanceSampleCube;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sampleCubeArray.Length; i++)
        {
            if (sampleCubeArray != null)
            {
                sampleCubeArray[i].transform.localScale = new Vector3(1, (AudioPeer.samples[i] * maxScale) + 2, 1);
            }
        }
    }
}
