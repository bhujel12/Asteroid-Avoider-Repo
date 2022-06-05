using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void Crash()
    {
        // Not destroying player as of now because a later script will give another life after watching an ad.
        gameObject.SetActive(false);
    }
}
