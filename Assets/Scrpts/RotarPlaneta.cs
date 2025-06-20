using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarPlaneta : MonoBehaviour
{
    public Vector3 velocidadRotacion = new Vector3(0, 10, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidadRotacion * Time.deltaTime);
    }
}