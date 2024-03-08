using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    public float frozenTime = 3f;
    public GameObject iceBlockPrefab;
    private bool isFrozen = false;
    private float frozenStartTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isFrozen)
        {
            Freeze();
        }


        if (isFrozen && Time.time - frozenStartTime >= frozenTime)
        {
            Unfreeze();
        }
    }

    void Freeze()
    {
        isFrozen = true;
        frozenStartTime = Time.time;

        Instantiate(iceBlockPrefab, transform.position, transform.rotation);
    }

    void Unfreeze()
    {
        isFrozen = false;
    }
}
