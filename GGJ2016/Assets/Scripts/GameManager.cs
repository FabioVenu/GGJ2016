using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public enum Status
    {
        InProgress = 0,
        Lost = 1,
        Won = 2
    }

    private Status GameState = Status.InProgress;

    public GameObject Player;
    public GameObject EvilCloud;

    public GameObject LostMessage;
    public GameObject VictoryMessage;

    public float MinEvilCloudRespawnDistance = 0.1f;
    public float MaxEvilCloudRespawnDistance = 10f;
    public float ScrollDisappearTime = 4;

    public static float FixedZ = -5;

    public int maxIngredients;
    public int numberOfIngredientsInRecipe;

    List<int> recipe ;

    public AudioClip  AudioVocal1;

    public AudioClip AudioVocalFail;
    public AudioClip AudioVocalWin;

    public List<GameObject> IngredientsPrefabs = new List<GameObject>();
    public List<GameObject> PowerUpsPrefabs = new List<GameObject>();

    public List<GameObject> IngredientsSpawnPoints = new List<GameObject>();
    public List<GameObject> PowerUpsSpawnPoints = new List<GameObject>();

    public List<Sprite> IngredientsSprites = new List<Sprite>();

    private List<GameObject> usedSpawnPoints = new List<GameObject>();

    public Image pergamena;
    public Image pergamenaItem1;
    public Image pergamenaItem2;
    public Image pergamenaItem3;


    [HideInInspector]
    public AudioSource AudioSource;

    [HideInInspector]
    public static GameManager Instance;

	// Use this for initialization
	void Start () {

        Instance = this;
        generateRecipe(numberOfIngredientsInRecipe, maxIngredients);

        // Spawn Ingredients!
        IngredientsSpawnPoints.Shuffle();
        foreach (var i in IngredientsPrefabs)
        {
            GameObject sp = getSpawnPointForIngredient();

            GameObject ingredient = Instantiate(i, sp.transform.position, new Quaternion(0, 0, 0, 1)) as GameObject;
        }

        System.Random rnd = new System.Random();

        // Spawn PoweUps!
        PowerUpsSpawnPoints.Shuffle();
        foreach (var pp in PowerUpsSpawnPoints)
        {
            GameObject prefab = PowerUpsPrefabs[rnd.Next(0, PowerUpsPrefabs.Count)];

            GameObject powerup = Instantiate(prefab, pp.transform.position, new Quaternion(0, 0, 0, 1)) as GameObject;           
        }

        AudioSource = gameObject.GetComponent<AudioSource>();
        //AudioSource.PlayOneShot(AudioVocal1);
                
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    // Will return a new position for the evil cloud, 
    public static Vector3 getRandomEvilCloudPosition()
    {
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        Vector2 newpos = new Vector2(Instance.Player.transform.position.x, Instance.Player.transform.position.y) + direction * Random.Range(Instance.MinEvilCloudRespawnDistance, Instance.MaxEvilCloudRespawnDistance);

        return new Vector3(newpos.x, newpos.y, FixedZ);
    }

    public void showLostMessage()
    {
        LostMessage.SetActive(true);

        if (GameState == Status.InProgress)        
            GameManager.Instance.AudioSource.PlayOneShot(AudioVocalFail);

        GameState = Status.Lost;
    }

    
    void generateRecipe(int size, int max)
    {
        List<int> allObjects = new List<int>();
        recipe = new List<int>();

        for (int i = 0 ; i < max ; i++)
        {
            allObjects.Add(i);
        }

        for (int i = 0; i < size; i++)
        {
            int k = Random.Range(0, allObjects.Count);
            int j = allObjects[k];
            recipe.Add(j);
            allObjects.Remove(j);
        }
        pergamenaItem1.sprite = IngredientsSprites[recipe[0]];
        pergamenaItem2.sprite = IngredientsSprites[recipe[1]];
        pergamenaItem3.sprite = IngredientsSprites[recipe[2]];

        pergamena.gameObject.SetActive(true);
        Invoke("disappear", ScrollDisappearTime);

    }

    public void checkIngredients()
    {
        int i = 0;
        List<int> inventory = Player.GetComponent<Inventory>().getInventory();
        foreach (int j in inventory)
        {
            if (recipe.Contains(j))
            {
                i++;
            }
        }

        if (i == recipe.Count)
        {
            VictoryMessage.SetActive(true);
        }

    }

    public GameObject getSpawnPointForIngredient()
    {        
        foreach (GameObject s in IngredientsSpawnPoints)
        {
            if (!usedSpawnPoints.Contains(s))
            {
                usedSpawnPoints.Add(s);
                return s;
            }
        }
        return null;
    }


    void disappear()
    {
        pergamena.gameObject.SetActive(false);
    }
    


}
