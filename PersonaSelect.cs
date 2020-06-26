using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PersonaSelect : MonoBehaviour
{

    internal GameObject Persona;
    internal TextMeshProUGUI NameOnButton;
    internal TextMeshProUGUI NameDisplay;
    internal Happiness_Script PersonaAttribute;


    // Start is called before the first frame update
    void Start()
    {

        NameOnButton = this.GetComponentInChildren<TextMeshProUGUI>();
        Persona = GameObject.Find(NameOnButton.text);

        // Gets us the Happiness Script of the target persona so we can use and manipulate it's functions
        PersonaAttribute = Persona.GetComponent<Happiness_Script>();
        NameDisplay = Persona.GetComponent<Happiness_Script>().NameDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPersona()
    {
        // Button was clicked - do something


        // Check if the Color of the bar happiness falls below a certain point

        if (PersonaAttribute.mHappiness < 50)
            PersonaAttribute.BarColor.color = PersonaAttribute.LowColor;
        else
            PersonaAttribute.BarColor.color = PersonaAttribute.FullColor;



        NameDisplay.text = NameOnButton.text;
        Debug.Log("This Persona Was Selected: " + NameOnButton.text);

        if (Persona.name == NameDisplay.text)
        {
            Persona.GetComponent<Happiness_Script>().Selected = true;
            PersonaAttribute.HappinessBar.gameObject.SetActive(true);
        }
        else
        {
            Persona.GetComponent<Happiness_Script>().Selected = false;
            PersonaAttribute.HappinessBar.gameObject.SetActive(false);
        }

    }
}
