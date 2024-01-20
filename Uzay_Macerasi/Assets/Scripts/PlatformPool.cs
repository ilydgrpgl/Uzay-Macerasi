using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;
    [SerializeField]
    GameObject deadPlatformPrefab = default;
    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();
    Vector2 platformPosition;
    Vector2 playerPosition;
    void Start()
    {
        ProducePlatform();
    }


    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y <
            Camera.main.transform.position.y + ScreenCalculators.instance.Height)
        {
            PlacePlatform();
        }
    }
    void ProducePlatform()//platform üret
    {
        platformPosition = new Vector2(0, 0);
        playerPosition = new Vector2(0, 0.5f);
        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<Platform>().Movement = true;


        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Movement = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Gold>().GoldOpen();// ilk 10 platformdaki altýnlarý biz veriyoruz manuel 
            }

            NextPlatformPosition();

        }
        GameObject deadPlatform = Instantiate(deadPlatformPrefab, platformPosition, Quaternion.identity);
        deadPlatform.GetComponent<DeadPlatform>().Movement = true;
        platforms.Add(deadPlatform);
        NextPlatformPosition();
    }
        // object pooling
        void PlacePlatform()//platform yerleþtir
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject temp;
                temp = platforms[i + 5];
                platforms[i + 5] = platforms[i];
                platforms[i] = temp;//
                platforms[i + 5].transform.position = platformPosition;
                if(platforms[i + 5].gameObject.tag=="Platform")//burada dinamik þekilde altýn yerleþtiriliyor
            {
                platforms[i + 5].GetComponent<Gold>().GoldClose();
                float randomGold=Random.Range(0.0f, 1.0f);
                if(randomGold > 0.5f)
                {
                    platforms[i + 5].GetComponent<Gold>().GoldOpen();
                }
            }
                NextPlatformPosition();
            }
        }
        void NextPlatformPosition()
        {
            platformPosition.y += 3.0f;
            float random = Random.Range(0.0f, 1.0f);
            if (random < 0.5f)
            {
                platformPosition.x = ScreenCalculators.instance.Width / 2;
            }
            else
            {
                platformPosition.x = -ScreenCalculators.instance.Width / 2;
            }
        }
    }

