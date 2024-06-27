using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setWorldBounds : MonoBehaviour
{
    private void Awake(){
        var mapRenderer = GetComponent<SpriteRenderer>();
        Globals.Map = mapRenderer;
    }
}
