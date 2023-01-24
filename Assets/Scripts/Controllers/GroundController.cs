using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private TerrainCollider coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<TerrainCollider>();
        PhysicMaterial material = new PhysicMaterial();
        material.dynamicFriction = 1;
        coll.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
