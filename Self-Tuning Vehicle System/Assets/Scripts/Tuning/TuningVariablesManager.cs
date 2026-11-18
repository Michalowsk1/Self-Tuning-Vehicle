using UnityEngine;
using UnityEngine.UI;

public class TuningVariablesManager : MonoBehaviour
{
    [SerializeField] private TuningSystem ts;
    [SerializeField] private Toggle toggle;
    [SerializeField] private InputField globalValue;
    [SerializeField] private InputField varianceValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ts.variablesInfo[gameObject.name] = (toggle.isOn, ts.variablesInfo[gameObject.name].currentValue, ts.variablesInfo[gameObject.name].variance,
                                            ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);

        if(globalValue != null)
        {
            ts.variablesInfo[gameObject.name] = (toggle.isOn, int.Parse(globalValue.text), ts.variablesInfo[gameObject.name].variance,
                                            ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);
        }

        if(varianceValue != null)
        {
            ts.variablesInfo[gameObject.name] = (toggle.isOn, ts.variablesInfo[gameObject.name].currentValue, int.Parse(varianceValue.text),
                                            ts.variablesInfo[gameObject.name].lastChangedHelped, ts.variablesInfo[gameObject.name].lastValueWasPositive);
        }
    }
}
