﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

    public float attrationForce;

    Rigidbody body;

    void Awake () {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        body.AddForce(transform.localPosition * -attrationForce);
    }
}
