using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float value;
    public float Value { 
        get => value; 
        private set {

            float oldValue = this.value;
            this.value = value;
            if(value != oldValue)
            {
                Debug.Log("Sending Event!");
                OnValueChanged?.Invoke(value);
            }

        }
    }

    [HideInInspector] public UnityEvent<float> OnValueChanged;

    public void AddValue(float addValue)
    {
        Value = Value + addValue;
    }

    public void SetValue(float value)
    {
        Value = value;
    }
}
