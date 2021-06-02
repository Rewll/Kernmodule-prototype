using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard : MonoBehaviour
{
    [SerializeField] private List<DataDummyHolder> data = new List<DataDummyHolder>();
    private Dictionary<string, FloatVariable> blackBoard = new Dictionary<string, FloatVariable>();

    private void Awake()
    {
        blackBoard = new Dictionary<string, FloatVariable>();
        foreach (DataDummyHolder d in data)
        {
            var fVariable = ScriptableObject.CreateInstance<FloatVariable>();
            fVariable.SetValue(d.value);
            fVariable.OnValueChanged = d.OnValueChanged;
            fVariable.OnValueChanged.AddListener((x) => d.value = x);
            blackBoard.Add(d.variableName, fVariable);
        }
    }

    public FloatVariable GetValueByName(string name)
    {
        if (blackBoard.ContainsKey(name))
        {
            return blackBoard[name];
        }
        Debug.LogWarning($"Variable {name} was not found in the blackboard dictionary!");
        return null;
    }
}

[System.Serializable]
public class DataDummyHolder
{
    public string variableName;
    public float value;
    public UnityEngine.Events.UnityEvent<float> OnValueChanged;
}