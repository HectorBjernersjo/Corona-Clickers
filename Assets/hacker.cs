using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hacker : MonoBehaviour

{
    static int infected;
    public Text Textis;
    public void Knappis()

    {
        infected += 1;

        Textis.text = "Infected: " +  infected.ToString();

    }

    void Start()
    {
        
    }

    // "nej stopp hihi"
    void Update()
    {
        
    }
}
