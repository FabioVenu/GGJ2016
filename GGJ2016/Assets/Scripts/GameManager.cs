using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject EvilCloud;

    public GameObject LostMessage;
    public GameObject VictoryMessage;

    public float MinEvilCloudRespawnDistance = 0.1f;
    public float MaxEvilCloudRespawnDistance = 10f;

    public static float FixedZ = -5;

    public int maxIngredients;
    public int numberOfIngredientsInRecipe;

    List<int> recipe ;

    public List<GameObject> IngredientsPrefabs = new List<GameObject>();
    public List<GameObject> IngredientsSpawnPoints = new List<GameObject>();
    public List<GameObject> PowerUpsSpawnPoints = new List<GameObject>();

    private List<GameObject> usedSpawnPoints = new List<GameObject>();

    public GameObject imagePergamena;
    public GameObject imagePergamena1;
    public GameObject imagePergamena2;
    public GameObject imagePergamena3;

    public List<GameObject> allSpawnedIngredients;
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
        SetText();
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
        IngredientsSpawnPoints.Shuffle();
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


    public void SetText()
    {
        imagePergamena1.GetComponent<Text>().text = GetText(recipe[0]);
        imagePergamena2.GetComponent<Text>().text = GetText(recipe[1]);
        imagePergamena3.GetComponent<Text>().text = GetText(recipe[2]);
        imagePergamena.SetActive(true);
    }
    public string GetText(int ingredientType)
    {
        foreach (GameObject g in allSpawnedIngredients)
        {
            if (g.GetComponent<Ingredient>().Type == ingredientType)
            {
                //return g.GetComponent<Ingredient>().GetComponent<SpriteRenderer>().GetComponent<Sprite>();
                Debug.Log(g.name);
                return g.name;
            }

        }
        return null;
    }


    


}
