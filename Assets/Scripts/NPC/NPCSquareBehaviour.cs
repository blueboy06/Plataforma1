using System;
using UnityEngine;

public class NPCSquareBehaviour : MonoBehaviour
{
    #region Attributes
    [SerializeField] GameObject groundGO;
    private SpriteRenderer spriteRenderer;
    float myTime = 0;
    [Header("Color Change Settings")]
    [SerializeField] private float colorChangeSpeed = 0.2f;
    [SerializeField] private Color startingColor;
    float sizeMultiplier = 0;
    #endregion

    //METHODS -----------------------------------------------------------------------------------------------

    #region Unity Methods
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(ReturnNameString("Cristina", 27));
        //Debug.LogWarning(ReturnNameString("Alberto", 34));
        //Debug.LogError(ReturnNameString("Sofía", 15));

        ChangeColor(startingColor);

    }

    // Update is called once per frame
    void Update()
    {
        //sizeMultiplier += Time.deltaTime;
        //transform.localScale = Vector3.one * sizeMultiplier;

        //PELIGRO: ESTO ES UN EJEMPLO DE VECTOR NUEVO. NO ME SIRVE PARA LO QUE ESTOY HACIENDO.
        //transform.localPosition = new Vector3(transform.localPosition.x + sizeMultiplier/100, transform.localPosition.y + sizeMultiplier/100, 0);


        //Color color2 = new Color(1, 1, 1);
        float hue = 0;
        hue += (Time.time * colorChangeSpeed) % 1;
        Color hueColor = Color.HSVToRGB(hue, 1f, 1f);
        ChangeColor(hueColor);


        myTime += Time.deltaTime;
        Debug.Log(myTime);
        Debug.LogWarning(Time.time);
    }
    #endregion 


    private void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

    /// <summary>
    /// My function returns a string with the name and age of an user
    /// </summary>
    /// <param name="name">The name of the user</param>
    /// <param name="age">The age of the user</param>
    /// <returns>A string with the name and age</returns>
    private string ReturnNameString(string name, int age)
    {
        return "Me llamo " + name + " y tengo " + age + " años.";
    }
}
