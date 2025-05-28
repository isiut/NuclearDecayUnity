using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenUI : MonoBehaviour
{
    public GameObject alphaParticlePrefab;
    public GameObject betaMinusParticlePrefab;
    public GameObject betaPlusParticlePrefab;
    public GameObject gammaParticlePrefab;
    public GameObject protonPrefab;
    public GameObject neutronPrefab;

    public TMP_Text decayErrorLabel;

    public void back()
    {
        Debug.Log("Back button pressed. Returning to the previous screen.");
        SceneManager.LoadScene("StartScene");
    }

    // TODO: Make decay modes non-selectable when they are impossible
    public void alpha()
    {
        Debug.Log("Alpha decay selected.");

        if (GameData.aNumber < 5 || GameData.zNumber < 3)
        {
            decayErrorLabel.text = "α decay not possible";
            return;
        }
        decayErrorLabel.text = "";

        GameObject particle = Instantiate(alphaParticlePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Rigidbody rb = particle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f)
            );
        }

        // Remove 2 protons and 2 neutrons from the atom
        GameData.aNumber -= 4;
        GameData.zNumber -= 2;

        for (int i = 0; i < 2; i++)
        {
            if (GameData.protons.Count > 0)
            {
                var lastProton = GameData.protons[^1];
                GameData.protons.RemoveAt(GameData.protons.Count - 1);
                Destroy(lastProton);
            }

            if (GameData.neutrons.Count > 0)
            {
                var lastNeutron = GameData.neutrons[^1];
                GameData.neutrons.RemoveAt(GameData.neutrons.Count - 1);
                Destroy(lastNeutron);
            }
        }

        Debug.Log($"After alpha decay: A = {GameData.aNumber}, Z = {GameData.zNumber}");

        ElementInfoUpdater elementInfoUpdater = FindFirstObjectByType<ElementInfoUpdater>();
        if (elementInfoUpdater != null)
        {
            elementInfoUpdater.UpdateElementInfo();
        }

        Destroy(particle, 5f);
    }

    public void betaMinus()
    {
        Debug.Log("Beta-minus decay selected.");

        if (GameData.aNumber - GameData.zNumber < 1)
        {
            decayErrorLabel.text = "β- decay not possible";
            return;
        }
        decayErrorLabel.text = "";

        GameObject particle = Instantiate(betaMinusParticlePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Rigidbody rb = particle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(
                Random.Range(-10f, 10f),
                Random.Range(-10f, 10f),
                Random.Range(-10f, 10f)
            );
        }

        // Transform a neutron into a proton
        if (GameData.neutrons.Count > 0)
        {
            var neutron = GameData.neutrons[^1];
            GameData.neutrons.RemoveAt(GameData.neutrons.Count - 1);
            Destroy(neutron);

            if (protonPrefab != null)
            {
                GameObject newProton = Instantiate(protonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newProton.transform.localScale = Vector3.one * 0.5f;
                GameData.protons.Add(newProton);
            }
            GameData.zNumber += 1;
        }

        Debug.Log($"After beta minus decay: A = {GameData.aNumber}, Z = {GameData.zNumber}");

        ElementInfoUpdater elementInfoUpdater = FindFirstObjectByType<ElementInfoUpdater>();
        if (elementInfoUpdater != null)
        {
            elementInfoUpdater.UpdateElementInfo();
        }

        Destroy(particle, 7f);
    }

    public void betaPlus()
    {
        Debug.Log("Beta-plus decay selected.");

        if (GameData.zNumber < 2)
        {
            decayErrorLabel.text = "β+ decay not possible";
            return;
        }
        decayErrorLabel.text = "";

        GameObject particle = Instantiate(betaPlusParticlePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Rigidbody rb = particle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(
                Random.Range(-10f, 10f),
                Random.Range(-10f, 10f),
                Random.Range(-10f, 10f)
            );
        }

        // Transform a proton into a neutron
        if (GameData.protons.Count > 0)
        {
            var proton = GameData.protons[^1];
            GameData.protons.RemoveAt(GameData.protons.Count - 1);
            Destroy(proton);

            if (neutronPrefab != null)
            {
                GameObject newNeutron = Instantiate(neutronPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newNeutron.transform.localScale = Vector3.one * 0.5f;
                GameData.neutrons.Add(newNeutron);
            }
            GameData.zNumber -= 1;
        }

        Debug.Log($"After beta plus decay: A = {GameData.aNumber}, Z = {GameData.zNumber}");

        ElementInfoUpdater elementInfoUpdater = FindFirstObjectByType<ElementInfoUpdater>();
        if (elementInfoUpdater != null)
        {
            elementInfoUpdater.UpdateElementInfo();
        }

        Destroy(particle, 7f);
    }

    public void gamma()
    {
        Debug.Log("Gamma decay selected.");
        GameObject particle = Instantiate(gammaParticlePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Rigidbody rb = particle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(
                Random.Range(-15f, 15f),
                Random.Range(-15f, 15f),
                Random.Range(-15f, 15f)
            );
        }

        Debug.Log($"After gamma decay: A = {GameData.aNumber}, Z = {GameData.zNumber}");

        ElementInfoUpdater elementInfoUpdater = FindFirstObjectByType<ElementInfoUpdater>();
        if (elementInfoUpdater != null)
        {
            elementInfoUpdater.UpdateElementInfo();
        }

        Destroy(particle, 5f);
    }
}
