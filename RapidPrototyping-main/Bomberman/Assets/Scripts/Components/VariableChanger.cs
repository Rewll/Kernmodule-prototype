using UnityEngine;

public class VariableChanger : MonoBehaviour
{
    public string variableName;
    public float amount;

    public void ChangeVariableForTarget(GameObject target)
    {
        target
            .GetComponent<BlackBoard>()?
            .GetValueByName(variableName)?
            .AddValue(amount);
    }

    public void ChangeVariableSelf()
    {
        GetComponent<BlackBoard>()?
        .GetValueByName(variableName)?
        .AddValue(amount);
    }
}
