using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class SetWorldBounds : MonoBehaviour
{
   private void Awake(){
    var bounds = GetComponent<SpriteRenderer>().bounds;
    Globals.WorldBounds = bounds;
   }
}
