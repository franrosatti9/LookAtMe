using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    [SerializeField] float _maxLifetime;
    float _lifetime;
    void Start()
    {
        _lifetime = 0;
    }

    void Update()
    {
        _lifetime += Time.deltaTime;
        if (_lifetime >= _maxLifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
