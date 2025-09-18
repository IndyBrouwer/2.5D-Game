using UnityEngine;

public class PuzzleCounter : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI puzzleCounterText;

    [SerializeField] private int totalPuzzles = 5;
    private int solvedPuzzles;

    void Start()
    {
        solvedPuzzles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
