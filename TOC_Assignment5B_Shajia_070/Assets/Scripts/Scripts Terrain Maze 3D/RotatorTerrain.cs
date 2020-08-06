using UnityEngine;
using System.Collections;

public class RotatorTerrain : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(10, 20, 35) * Time.deltaTime);
    }
}
