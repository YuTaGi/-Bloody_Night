using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    private int Life = 3;
    public TextMeshProUGUI LifeText;

    public void life()
    {
        if (gameObject.CompareTag("Enemy"))
        {
           Life--;
           LifeText.text = "LIFE : " + Life.ToString();

        }
    }
}
