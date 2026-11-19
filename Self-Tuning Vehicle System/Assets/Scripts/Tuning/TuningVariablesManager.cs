using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TuningVariablesManager : MonoBehaviour
{
    [SerializeField] private TuningSystem ts;
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMP_InputField globalValue;
    [SerializeField] private TMP_InputField varianceValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ts.variablesInfo[gameObject.name] = (toggle.isOn, ts.variablesInfo[gameObject.name].currentValue, ts.variablesInfo[gameObject.name].variance,
                                            ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);
    }

    public void UpdateGlobalValue()
    {
        ts.variablesInfo[gameObject.name] = (toggle.isOn, float.Parse(globalValue.text), ts.variablesInfo[gameObject.name].variance,
                                            ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);
    }

    public void UpdateVarianceValue()
    {
        ts.variablesInfo[gameObject.name] = (toggle.isOn, ts.variablesInfo[gameObject.name].currentValue, float.Parse(varianceValue.text),
                                        ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);
    }
}
