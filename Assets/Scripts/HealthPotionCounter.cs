using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPotionCounter : MonoBehaviour
{
    public TMP_Text text;
    public static int potionAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ": " + potionAmount.ToString();
    }
}
