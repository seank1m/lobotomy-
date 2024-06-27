using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    
    private Bounds cameraBounds;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;
    private Vector3 dragOrigin;
    // Start is called before the first frame update
    
    

    private void Awake(){
        mapMinX = Globals.Map.transform.position.x - Globals.Map.bounds.size.x/2f;
        mapMaxX = Globals.Map.transform.position.x + Globals.Map.bounds.size.x/2f;

        mapMinY = Globals.Map.transform.position.y - Globals.Map.bounds.size.y/2f;
        mapMaxY = Globals.Map.transform.position.y + Globals.Map.bounds.size.y/2f;
    }


    private Vector3 ClampCamera(Vector3 targetPosition){
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x,minX,maxX);
        float newY = Mathf.Clamp(targetPosition.y,minY,maxY);

        return new Vector3(newX,newY,targetPosition.z);
    }
    // Update is called once per frame
    private void Update()
    {
        PanCamera();
    }

   
    private void PanCamera(){
        if(Input.GetMouseButtonDown(0)){
           dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0)){
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition); 

        
            cam.transform.position = ClampCamera(cam.transform.position + difference);
    }
        }

        
}
