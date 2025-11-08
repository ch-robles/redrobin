using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiasCounter : MonoBehaviour
{
    public TMP_Text text;
    public static int diasAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ": " + diasAmount.ToString();
    }
}
