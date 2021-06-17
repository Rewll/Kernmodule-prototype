using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum submarineMoveTypes { Torpedo, Sonar, Boost , Dive, Upturn, Anchor};

public class SubmarineManager : SingleTon<SubmarineManager>
{
    public List<submarineMoveTypes> moveSequence = new List<submarineMoveTypes>();

    [Header("Submarine Moves")]
    [SerializeField]
    float SecondsBetweenMoves;
    public bool isExecutingMoves;

    [Header("Submarine Move events")]
    public UnityEvent Dive;
    public UnityEvent Upturn;

    public UnityEvent Torpedo;
    public UnityEvent Sonar;
    public UnityEvent Boost;
    public UnityEvent Anchor;
    private void Awake()
    {
        Instance = this;
    }

    public void testVoid()
    {
        Debug.Log("TestVoid");

    }

    public void addMoveToSequence(int moveType)
    {
        moveSequence.Add((submarineMoveTypes)moveType);
        if (moveSequence.Count == 3)
        {
            StartCoroutine(executeMoveSequence());
        }
    }

    IEnumerator executeMoveSequence()
    {
        isExecutingMoves = true;
        Debug.Log("executing moves");
        foreach (submarineMoveTypes moves in moveSequence)
        {
            switch (moves)
            {
                case submarineMoveTypes.Torpedo:
                    Torpedo.Invoke();
                    break;
                case submarineMoveTypes.Sonar:
                    Sonar.Invoke();
                    break;
                case submarineMoveTypes.Boost:
                    Boost.Invoke();
                    break;
                case submarineMoveTypes.Dive:
                    Dive.Invoke();
                    break;
                case submarineMoveTypes.Upturn:
                    Upturn.Invoke();
                    break;
                case submarineMoveTypes.Anchor:
                    Anchor.Invoke();
                    break;
            }
            yield return new WaitForSeconds(SecondsBetweenMoves);
        }
        moveSequence.Clear();
        isExecutingMoves = false;
    }
}