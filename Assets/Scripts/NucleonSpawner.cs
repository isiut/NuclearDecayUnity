using UnityEngine;

public class NucleonSpawner : MonoBehaviour
{
    public GameObject protonPrefab;
    public GameObject neutronPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int aNumber = GameData.aNumber;
        int zNumber = GameData.zNumber;

        int numberOfProtons = zNumber;
        int numberOfNeutrons = aNumber - zNumber;

        Debug.Log($"Spawning {numberOfProtons} protons and {numberOfNeutrons} neutrons for A={aNumber}, Z={zNumber}");

        int protonsSpawned = 0;
        int neutronsSpawned = 0;

        for (int i = 0; i < aNumber; i++)
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));

            // Alternate spawning, but ensure we don't exceed the desired count for each type
            if ((i % 2 == 0 && protonsSpawned < numberOfProtons) || neutronsSpawned >= numberOfNeutrons)
            {
                GameObject proton = Instantiate(protonPrefab, position, Quaternion.identity);
                proton.transform.localScale = Vector3.one * 0.5f;
                protonsSpawned++;
            }
            else
            {
                Instantiate(neutronPrefab, position, Quaternion.identity);
                neutronPrefab.transform.localScale = Vector3.one * 0.5f;
                neutronsSpawned++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
