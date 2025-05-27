using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public TMP_InputField protonInputField;
    public TMP_InputField neutronInputField;

    public TMP_Text errorText;

    public void startGame()
    {
        string protonText = protonInputField.text;
        string neutronText = neutronInputField.text;

        int protonCount = int.Parse(protonText);
        int neutronCount = int.Parse(neutronText);

        bool isValidNucleon = protonCount > 0 && neutronCount >= 0 && protonCount <= 118 && neutronCount <= 300;

        if (!isValidNucleon)
        {
            errorText.text = "Invalid nucleon count.";
        }
        else
        {
            GameData.protonCount = protonCount;
            GameData.neutronCount = neutronCount;

            SceneManager.LoadScene("MainScene");
        }
    }
}
