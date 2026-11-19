using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TuningVariablesManager : MonoBehaviour
{
    [SerializeField] private TuningSystem ts;
    [SerializeField] private VehicleBehaviour vh;
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMP_InputField globalValue;
    [SerializeField] private TMP_InputField varianceValue;
    [SerializeField] private TextMeshProUGUI varianceValueText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        varianceValueText.text = "Variance: " + ts.variablesInfo[gameObject.name].variance;

        ts.variablesInfo[gameObject.name] = (toggle.isOn, ts.variablesInfo[gameObject.name].currentValue, ts.variablesInfo[gameObject.name].variance,
                                            ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);
    }

    public void UpdateGlobalValue()
    {
        if (globalValue.text == null)
            return;

        ts.variablesInfo[gameObject.name] = (toggle.isOn, float.Parse(globalValue.text), ts.variablesInfo[gameObject.name].variance,
                                            ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);

        switch (gameObject.name)
        {
            case "accelerationAdjuster":
                vh.accelerationAdjuster = float.Parse(globalValue.text);
                break;

            case "speedUpIncrement":
                vh.speedUpIncrement = float.Parse(globalValue.text);
                break;

            case "minimumSteeringPower":
                vh.minimumSteeringPower = float.Parse(globalValue.text);
                break;

            case "steeringEnhancer":
                vh.steeringEnhancer = float.Parse(globalValue.text);
                break;

            case "sideDetectDistance":
                vh.sideDetectDistance = float.Parse(globalValue.text);
                break;

            case "angledDetectDistance":
                vh.angledDetectDistance = float.Parse(globalValue.text);
                break;

            case "straightDetectDistance":
                vh.straightDetectDistance = float.Parse(globalValue.text);
                break;
        }
    }

    public void UpdateVarianceValue()
    {
        if (varianceValue.text == null)
            return;

        ts.variablesInfo[gameObject.name] = (toggle.isOn, ts.variablesInfo[gameObject.name].currentValue, float.Parse(varianceValue.text),
                                        ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);
    }
}
