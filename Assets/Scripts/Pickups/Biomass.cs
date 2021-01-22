using System.Collections;
using UnityEngine;

public class Biomass : MonoBehaviour, IPickupable
{
    [SerializeField] private string pName = "";
    private AudioSource audioSource;
    private float volume;

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        volume = 1f;
    }

    public void Spawn(Transform spawnPoint)
    {
        ObjectPooler.Instance.GetPooledObject(pName, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void OnPickup(Inventory inv)
    {
        PlaySound();
        inv.addToBiomass();
        gameObject.SetActive(false);
    }

    public void PlaySound()
    {
        AudioClip clip = audioSource.clip;
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position, volume);
    }
}
