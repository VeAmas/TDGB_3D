using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Device : MonoBehaviour {

    public string deviceName;
    public Text nameTagPrefab;
    private float height;
    private Text nameTag;

    // Start is called before the first frame update
    void Start() {
        float size_y = gameObject.GetComponent<Renderer>().bounds.size.y;

        height = (size_y) * 1.1f;

        nameTag = (Text)Instantiate(nameTagPrefab);
        nameTag.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), true);
    }

    // Update is called once per frame
    void Update() {
        nameTag.GetComponent<Transform>().position = Camera.main.WorldToScreenPoint(gameObject.transform.parent.position + new Vector3(0, height, 0));
    }

    public void UpdateName() {

        if (nameTag != null) {
            nameTag.text = deviceName;
            Debug.Log(nameTag.text);

        }
    }
}
