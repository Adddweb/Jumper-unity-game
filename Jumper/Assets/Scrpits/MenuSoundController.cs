using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundController : MonoBehaviour
{
    public AudioSource AS;
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
        AS.volume = 0.2f;
    }

    void Update()
    {
        
    }
}
