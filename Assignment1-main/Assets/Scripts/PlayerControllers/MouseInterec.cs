using UnityEngine;
using UnityEngine.UI;

public class MouseInterec : MonoBehaviour
{
    public Image mouseImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.pink;

    public void SetInteract(bool canInteract)
    {
        mouseImage.color = canInteract ? interactColor : normalColor;
    }
}
