using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Network : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject entry;
    private Entry entryScript;
    void Start()
    {
        entry = GameObject.Find("Entry");
        entryScript = entry.GetComponent<Entry>();
    }

    // Update is called once per frame
    void Update()
    {
        if(entryScript != null)
        {
            entryScript.clientScript.NullCheck();
            entryScript.clientScript.AppearPlayers();
        }
    }
}