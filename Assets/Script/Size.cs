using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size {

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(504, 896, false, 60);

    }
}
