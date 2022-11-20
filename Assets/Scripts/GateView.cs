using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Image background;
    [SerializeField] private Image topPanel;

    [SerializeField] private GameObject expandLable;
    [SerializeField] private GameObject shrinkLable;
    [SerializeField] private GameObject upLable;
    [SerializeField] private GameObject downLable;

    [SerializeField] private Color positiveColor;
    [SerializeField] private Color negativeColor;    

    private enum Lables
    {
        expandLable,
        shrinkLable,
        upLable,
        downLable
    }

    public void UpdateGateView(int value, DeformationType deformationType)
    {
        if (value > 0)
            SetGate(positiveColor, value, deformationType);
        else
            SetGate(negativeColor, value, deformationType);
    }

    private void SetGate(Color color, int value, DeformationType deformationType)
    {
        topPanel.color = color;
        background.color = new Color(1, 1, 1, 0.5f) * color;

        if (value > 0)
        {
            text.text = $"+{value}";

            if (deformationType == DeformationType.Width)
                ChangeTopPanel(Lables.expandLable);
            else
                ChangeTopPanel(Lables.upLable);
        }
        else
        {
            text.text = value.ToString();

            if (deformationType == DeformationType.Width)
                ChangeTopPanel(Lables.shrinkLable);
            else
                ChangeTopPanel(Lables.downLable);
        }

        void ChangeTopPanel(Lables lable)
        {
            GameObject[] lables = { expandLable, shrinkLable, upLable, downLable };

            foreach (GameObject go in lables)
            {
                if (go == lables[(int)lable])
                    go.SetActive(true);
                else
                    go.SetActive(false);

            }
        }
    }
}
