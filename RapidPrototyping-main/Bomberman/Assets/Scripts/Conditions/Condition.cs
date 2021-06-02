using UnityEngine;
[System.Serializable]
public class Condition
{
    public enum CompareType { Equal, Less, Greater, LEqual, GEqual, NotEqual }
    public string name;
    public FloatHolder valueOne;
    public CompareType compareType;
    public FloatHolder valueTwo;
    
    public bool Evaluate(GameObject target)
    {
        Debug.Log($"Evaluating Condition: {valueOne.GetValue(target)} and {valueTwo.GetValue(target)}");
        switch (compareType)
        {
            case CompareType.Equal:
                return valueOne.GetValue(target) == valueTwo.GetValue(target);
            case CompareType.Less:
                return valueOne.GetValue(target) < valueTwo.GetValue(target);
            case CompareType.Greater:
                return valueOne.GetValue(target) > valueTwo.GetValue(target);
            case CompareType.LEqual:
                return valueOne.GetValue(target) <= valueTwo.GetValue(target);
            case CompareType.GEqual:
                return valueOne.GetValue(target) >= valueTwo.GetValue(target);
            case CompareType.NotEqual:
                return valueOne.GetValue(target) != valueTwo.GetValue(target);
        }
        return false;
    }
}

[System.Serializable]
public class FloatHolder
{
    public enum FloatType { BlackBoard, FloatVariable, Constant }
    public FloatType type;
    public float constantValue;
    public FloatVariable floatVariable;
    public string blackBoardVariableName;

    public float GetValue(UnityEngine.GameObject target)
    {
        switch (type)
        {
            case FloatType.BlackBoard:
                var bb = target.GetComponent<BlackBoard>();
                if(bb != null)
                {
                    var floatVar = bb.GetValueByName(blackBoardVariableName);
                    if(floatVar != null)
                    {
                        return floatVar.Value;
                    }
                    else
                    {
                        UnityEngine.Debug.LogWarning($"Value {blackBoardVariableName} not found in BlackBoard!");
                        return 0;
                    }
                }
                break;
            case FloatType.FloatVariable:
                return floatVariable.Value;
            case FloatType.Constant:
                return constantValue;
        }
        return 0;
    }
}