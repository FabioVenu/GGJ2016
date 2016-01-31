using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    [HideInInspector]
    public static GameManager Instance;

	// Use this for initialization
	void Start () {

        Instance = this;
        generateRecipe(numberOfIngredientsInRecipe, maxIngredients);
        
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

}
