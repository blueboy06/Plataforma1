using UnityEngine;

public class NPCColor : MonoBehaviour
{
    private float contador = 0f;
    [Header("Time Settings")]
    [SerializeField] private float tiempoParaCambio = 2f;
    private SpriteRenderer spriteRenderer;
    [Header("Colors")]
    [SerializeField] private Color newColor;

    [Header("Hue Values")]
    [Range(0, 360)][SerializeField] int minHue;
    [Range(0, 360)][SerializeField] int maxHue;
    [Header("Saturation Values")]
    [Range(0, 100)][SerializeField] int minSaturation;
    [Range(0, 100)][SerializeField] int maxSaturation;
    [Header("Value Values")]
    [Range(0, 100)][SerializeField] int minValue;
    [Range(0, 100)][SerializeField] int maxValue;
    int randomHue;
    int randomSaturation;
    int randomValue;


    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        ChangeColor(newColor);
    }

    void Update()
    {
        contador = contador + Time.deltaTime;
        if (contador >= tiempoParaCambio)
        {
            contador = 0f;
            //ChangeColor(new Color(Random.value, Random.value, Random.value));
            //ChangeColor(Random.ColorHSV());

            randomHue = Random.Range(minHue, maxHue + 1);
            randomSaturation = Random.Range(minSaturation, maxSaturation + 1);
            randomValue = Random.Range(minValue, maxValue + 1);
            ChangeColor(Color.HSVToRGB(randomHue / 360f, randomSaturation / 100f, randomValue / 100f));
        }


    }

    private void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

}