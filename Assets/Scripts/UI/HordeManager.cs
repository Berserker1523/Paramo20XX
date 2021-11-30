using System.Collections;
using UnityEngine;
using TMPro;
using System.Text;
using DG.Tweening;

public class HordeManager : MonoBehaviour
{
    private TMP_Text hordeText;
    private int currentHorde;

    /*private const int ColorChangeCycles = 8;
    private int currentColorChangeCycles = 0;
    private const float ColorChangeTime = 1f;
    private float currentColorChangeTime = 0;

    private Color NormalColor = Color.white;
    private Color ChangingColor = new Color(1, 1, 1, 0.3f);
    private Color currentColor;*/

    // Start is called before the first frame update
    void Awake()
    {
        hordeText = GetComponent<TMP_Text>();
        //currentColor = NormalColor;
    }

    public void AddHorde()
    {
        currentHorde++;
        StringBuilder newHordeText = new StringBuilder();
        switch (currentHorde)
        {
            case 1:
                newHordeText.Append("a");
                break;
            case 2:
                newHordeText.Append("b");
                break;
            case 3:
                newHordeText.Append("c");
                break;
            case 4:
                newHordeText.Append("d");
                break;
            case 5:
                newHordeText.Append("e");
                break;
            default:
                newHordeText.Append(currentHorde);
                break;
        }
        hordeText.text = newHordeText.ToString();
        hordeText.transform.DOShakePosition(1f, 0.1f);
        //currentColorChangeCycles = 0;
    }

    /*private void Update()
    {
        ColorChange();
    }

    private void ColorChange()
    {
        if (currentColorChangeCycles >= ColorChangeCycles)
            return;

       Color toColor = Equals(currentColor, NormalColor) ? ChangingColor : NormalColor;

        currentColorChangeTime += Time.deltaTime;
        Color newColor = Color.Lerp(hordeText.color, toColor, currentColorChangeTime);
        hordeText.color = newColor;

        if (currentColorChangeTime >= ColorChangeTime)
        {
            currentColor = toColor;
            currentColorChangeTime = 0;
            currentColorChangeCycles += 1;
        }
    }*/
}
