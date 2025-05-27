using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public TMP_InputField aInputField;
    public TMP_InputField zInputField;

    public TMP_Text errorText;

    public void startGame()
    {
        string aText = aInputField.text;
        string zText = zInputField.text;

        int aNumber = int.Parse(aText);
        int zNumber = int.Parse(zText);

        bool isValidNucleon = aNumber > 0 && zNumber > 0 && aNumber <= 300 && zNumber <= 118 && aNumber >= zNumber;

        if (!isValidNucleon)
        {
            errorText.text = "Invalid nucleon counts.";
        }
        else
        {
            GameData.aNumber = aNumber;
            GameData.zNumber = zNumber;

            SceneManager.LoadScene("MainScene");
        }
    }
}
