using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


[System.Serializable]
public class DeviceData {
    public int state;
    public String deviceName;
    public String deviceId;
}

[System.Serializable]
public class DeviceDataList {
    public DeviceData[] data;
}
public class DeviceDataController : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void InitialDevice();

    long nextUpdateTime = 0;
 
    public int updateInterval = 1000;

    DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);

    // Start is called before the first frame update
    void Start() {
        //InitialDevice();

        //setDeviceName("{\"data\":[{\"deviceId\": \"OVDS1\", \"deviceName\": \"三大城市的\"}, {\"deviceId\": \"OVDS2\", \"deviceName\": \"算得上是\"}]}");
    }


    // Update is called once per frame
    void Update()
    {
        return;
        System.Random rd = new System.Random();
        long currentMillis = (DateTime.Now.Ticks - dtFrom.Ticks) / 10000;
        if (currentMillis > nextUpdateTime) {
            nextUpdateTime = currentMillis + updateInterval;
            DeviceData data = new DeviceData();
            data.deviceName = "test1";
            data.state = rd.Next() % 4;
            SetDeviceData("{\"data\":[{\"deviceId\": \"OVDS1\", \"state\": 2}, {\"deviceId\": \"OVDS2\", \"state\": 1}]}");
        }
    }

    public void SetDeviceData (String dataJson) {
        DeviceData[] datas = JsonUtility.FromJson<DeviceDataList>(dataJson).data;

        for (int outI = 0; outI < datas.Length; outI++) {
            GameObject[] objs = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
            
            for (int i = 0; i < objs.Length; i++) {
                if (objs[i].tag == "Device" && objs[i].transform.parent.name == datas[outI].deviceId) {
                    objs[i].GetComponent<cakeslice.Outline>().color = datas[outI].state;
                    break;
                }
            }
        }
    }

    public void setDeviceName(String dataJson) {
        Debug.Log(dataJson);
        DeviceData[] datas = JsonUtility.FromJson<DeviceDataList>(dataJson).data;
        for (int outI = 0; outI < datas.Length; outI++) {
            GameObject[] objs = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];

            for (int i = 0; i < objs.Length; i++) {
                if (objs[i].tag == "Device" && objs[i].transform.parent.name == datas[outI].deviceId) {

                    Debug.Log(datas[outI].deviceId);

                    objs[i].GetComponent<Device>().deviceName = datas[outI].deviceName;
                    objs[i].GetComponent<Device>().UpdateName();
                    break;
                }
            }
        }
    }
}
