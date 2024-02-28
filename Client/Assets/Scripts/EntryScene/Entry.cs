using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour
{
    // Start is called before the first frame update
    //public TMP_InputField input;

    private int i = 0;

    public Connect clientScript;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Push()
    {

        if (/*!string.IsNullOrWhiteSpace(input.text)*/ true)
        {
            clientScript.userName = "name"/*input.text*/;
            clientScript.position = this.transform.position;
            clientScript.ConnectToServer();

            SceneManager.LoadScene("Game");
        }

    }
}
