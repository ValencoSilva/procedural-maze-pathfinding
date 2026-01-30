using UnityEngine;
using TMPro;

/// Mostra informações do labirinto e tempo
public class MazeHUD : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public BallController ball;

    void Update()
    {
        infoText.text =
            $"Time: {ball.ElapsedTime:F2}s\n" +
            $"Size: {GameManager.Instance.selectedMazeSize}\n" +
            $"AI: {GameManager.Instance.selectedAI}\n" +
            $"Seed: {GameManager.Instance.seed}";
    }
}


/*
HOW THIS SCRIPT WORKS:
This script connects the user interface with the maze system
It reads UI inputs such as buttons or sliders and triggers maze generation
or game actions based on player interaction
*/
