using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SectionTrigger"))
        {
            Instantiate(roadSection, new Vector3(0, 0, 113), Quaternion.identity);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
