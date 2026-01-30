using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Controls the game's main menu interface
public class UIManager : MonoBehaviour
{
    public Dropdown iaDropdown;
    public Dropdown sizeDropdown;
    public InputField seedInput;
    public Toggle randomToggle;


    //Starts the game with the selected configurations
    public void StartGame()
    {

        //IA
        switch (iaDropdown.value)
        {
            case 0: GameManager.Instance.selectedAI = PathfindingType.AStar; break;
            case 1: GameManager.Instance.selectedAI = PathfindingType.BFS; break;
            case 2: GameManager.Instance.selectedAI = PathfindingType.DFS; break;
        }

     
        //Size
        switch (sizeDropdown.value)
        {
            case 0: GameManager.Instance.selectedMazeSize = MazeSize.S10x10; break;
            case 1: GameManager.Instance.selectedMazeSize = MazeSize.S25x25; break;
            case 2: GameManager.Instance.selectedMazeSize = MazeSize.S50x50; break;
        }

        // Seed
        GameManager.Instance.useRandomSeed = randomToggle.isOn;

        if (!randomToggle.isOn)
            int.TryParse(seedInput.text, out GameManager.Instance.seed);

        GameManager.Instance.PrepareSeed();

        //DEBUG
        //Debug.Log("UI -> AI: " + GameManager.Instance.selectedAI);
        //Debug.Log("UI -> Size: " + GameManager.Instance.GetMazeDimension());
        //Debug.Log("UI -> Seed: " + GameManager.Instance.seed);

        SceneManager.LoadScene("SampleScene");
    }
}
