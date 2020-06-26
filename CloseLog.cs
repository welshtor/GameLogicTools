using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseLog : MonoBehaviour
{

    internal GameObject Persona;
    internal TextMeshProUGUI PersonaName;
    internal Happiness_Script PersonaAttribute; 
    // Start is called before the first frame update
    void Start()
    {
        PersonaName = GameObject.Find("PersonaName").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void CloseLogFunction()
    {
        Persona = GameObject.Find(PersonaName.text);
        PersonaAttribute = Persona.GetComponent<Happiness_Script>();

        PersonaAttribute.PersonaLog.SetActive(false);
        PersonaAttribute.LogOpen = false;
    }
}
