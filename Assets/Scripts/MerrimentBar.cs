using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class MerrimentBar : MonoBehaviour
{
    private float fillAmount;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        fillAmount = MerrimentController.CurrentMerriment / MerrimentController.MaxMerriment;

        fill.fillAmount = fillAmount;
    }
}
