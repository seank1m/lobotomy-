using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;
    // Start is called before the first frame update
    
    private Bounds _cameraBounds;
    private Vector3 _targetPosition;

    private void Start(){
        var height = cam.orthographicSize;
        var width = height * cam.aspect;

        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.extents.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.extents.y - height;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(new Vector3(minX,minY,0.0f), new Vector3(maxX,maxY,0.0f));
    }
    // Update is called once per frame
    private void Update()
    {
        PanCamera();
    }

    private Vector3 getCameraBounds(){
        return new Vector3(Mathf.Clamp(_targetPosition.x, _cameraBounds.min.x,_cameraBounds.max.x), Mathf.Clamp(_targetPosition.y,_cameraBounds.min.y, _cameraBounds.max.y),0.0f);
    }
    private void PanCamera(){
        if(Input.GetMouseButtonDown(0)){
           dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0)){
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition); 

            _targetPosition = difference;
            _targetPosition = getCameraBounds();
            cam.transform.position += _targetPosition;
    }
        }

        
}
