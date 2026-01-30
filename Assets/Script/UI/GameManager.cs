using UnityEngine;


/// Controla a configuracao escolhidas no menu e mantem elas entre cenas

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Enum para tipos de pathfinding disponíveis
    [Header("Configurações")]
    public PathfindingType selectedAI = PathfindingType.AStar;
    public MazeSize selectedMazeSize = MazeSize.S10x10;

    // Configurações de seed
    [Header("Seed")]
    public bool useRandomSeed = true;
    public int seed;

    //Awake ao inves de Start pois deve ser executado antes de qualquer outro script na cena para evitar problemas de inicialização
    private void Awake()
    {
        //Impedir múltiplas instâncias do GameManager(Game maneger do Menu permanece do Maze)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        
        }
        else
        {
          
            Destroy(gameObject);
        }
    }



    /// Retorna o tamanho real do labirinto
    public int GetMazeDimension()
    {
        switch (selectedMazeSize)
        {
            case MazeSize.S10x10: return 10;
            case MazeSize.S25x25: return 25;
            case MazeSize.S50x50:
                return 50;
            default: return 10;
        }
    }

 
    /// Gera a seed apenas uma vez
    public void PrepareSeed()
    {
        if (useRandomSeed)
        {
            seed = Random.Range(1, int.MaxValue);
        }
        // se não for random, usa o valor digitado no Menu
    }

 
    /// Retorna a seed atual (não gera uma nova)
    public int GetSeed()
    {
        return seed;
    }
}


/*
HOW THIS SCRIPT WORKS:
This script manages global game state and settings
It stores player selections such as maze size, seed, and AI type,
and makes this data available to other systems when the game starts
*/
