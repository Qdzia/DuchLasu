using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text textHP;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        textHP.text = ("Hp  000");
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text = ("Hp  " + player.hp.ToString());
    }
}
