using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelect : MonoBehaviour
{

    bool isMouseDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMouseDown) {
            isMouseDown = true;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane));
            Ray ray = new Ray(Camera.main.transform.position, mouseWorldPosition - Camera.main.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log(hit.collider.gameObject.name);
            }
        } else if (Input.GetMouseButtonUp(0)) {
            isMouseDown = false;
        }

    }
}
