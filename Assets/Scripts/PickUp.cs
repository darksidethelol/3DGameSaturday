﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void Update()
    {
        Rotation();
    }
    public virtual void Picked()
    {
        Debug.Log("Picked up");
        GameManager.gameManager.PlayClip(GameManager.gameManager.pickUpClip);
        Destroy(this.gameObject);
    }
    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 5f, 0));
    }
}
