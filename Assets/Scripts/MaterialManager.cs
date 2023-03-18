using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{

    [SerializeField] private Renderer _renderer;

    public void SetMaterial(Material material) {
        foreach (Transform t in transform)
        {
            t.gameObject.GetComponent<Renderer>().material = material;
        }
    }
}
