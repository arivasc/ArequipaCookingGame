using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limite : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("nave"))
        {
            Debug.Log("La nave ha tocado el límite inferior.");
        }
    }
}
