using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum submarineMoveTypes { Torpedo, Sonar, Grab, Dive, Upturn, Anchor };

public class SubmarineManager : SingleTon<SubmarineManager>
{
    public List<submarineMoveTypes> moveSequence = new List<submarineMoveTypes>();
    public List<Transform> allEnemies = new List<Transform>();
    public GameObject winPanel;

    [Header("Submarine Moves")]
    [SerializeField]
    float SecondsBetweenMoves;
    public bool isExecutingMoves;

    [Header("Submarine Move events")]
    public UnityEvent Dive;
    public UnityEvent Upturn;

    public UnityEvent Torpedo;
    public UnityEvent Sonar;
    public UnityEvent Grab;
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
                case submarineMoveTypes.Grab:
                    Grab.Invoke();
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

    public void Win()
    {
        Debug.Log("PLAYER HAS WON");
        StartCoroutine(win());
    }

    IEnumerator win()
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        Application.Quit();
    }
}