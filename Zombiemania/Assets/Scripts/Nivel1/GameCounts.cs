using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCounts : MonoBehaviour
{
    // Start is called before the first frame update
    public int zombieCount;
    GameObject zombieText;
    public int bulletCount;
    GameObject bulletText;



    void Start()
    {
        zombieCount = 0;
        bulletCount = 200;
        zombieText = GameObject.Find("ScoreC");
        bulletText = GameObject.Find("AmmoC");
    }

    // Update is called once per frame
    void Update()
    {
        zombieText.GetComponent<Text>().text = zombieCount.ToString();
        bulletText.GetComponent<Text>().text = bulletCount.ToString();
    }
}
