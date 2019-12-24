using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Communication : MonoBehaviour {
    //引用jslib的Hello()方法
    [DllImport("__Internal")]
    private static extern void Hello();
    //测试UI，我们的目的是用jslib的Hello()方法调用网页的js方法。然后用js方法调用Unity方法。
    //这样就完成了Unity和网页中的方法互相调用。最后MyText会显示Hello, world!
    public Text MyText;

    void Start() {
        //我们程序一开始就调用jslib的方法Hello()
        Hello();
    }
    //测试 网页调用此方法
    public void TestMethod(string text) {
        MyText.text = text;
    }
}