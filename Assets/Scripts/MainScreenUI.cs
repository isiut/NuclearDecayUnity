using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenUI : MonoBehaviour
{
    public GameObject alphaParticlePrefab;
    public GameObject betaMinusParticlePrefab;
    public GameObject betaPlusParticlePrefab;
    public GameObject gammaParticlePrefab;

    public void back()
    {
        Debug.Log("Back button pressed. Returning to the previous screen.");
        SceneManager.LoadScene("StartScene");
    }

    public void alpha()
    {
        Debug.Log("Alpha decay selected.");

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
        Destroy(particle, 5f);
    }

    public void betaMinus()
    {
        Debug.Log("Beta-minus decay selected.");

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
        Destroy(particle, 7f);
    }

    public void betaPlus()
    {
        Debug.Log("Beta-plus decay selected.");

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
        Destroy(particle, 5f);
    }
}
