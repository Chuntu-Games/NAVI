using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class explodeGhost : MonoBehaviour
{

    public ParticleSystem system;
    public MeshRenderer mesh;
    public BoxCollider collider;
    private Vector3 position1, position2, position3;
    private float coolDownPeriodInSeconds;
    private float timeStamp;
    public bool exploded;
    public bool changePlayerPos;
    public GameObject ghost;
    public AudioSource audioScream;
    public AudioSource audioExplosion;
    public Volume volume;
    Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        exploded = false;
        coolDownPeriodInSeconds = 3.0f;
        timeStamp = Time.time + coolDownPeriodInSeconds;
        position1 = new Vector3(297.6f, 50.87f, 387.35f);
        position2 = new Vector3(297.6f, 50.87f, 128.0f);
        position3 = new Vector3(496.0f, 50.87f, 232.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (exploded && (timeStamp <= Time.time))
        {
            system.Stop();
            mesh.enabled = true;
            collider.enabled = true;
            exploded = false;
            audioScream.enabled = true;

            float dist1 = Vector3.Distance(position1, ghost.transform.position);
            float dist2 = Vector3.Distance(position2, ghost.transform.position);
            float dist3 = Vector3.Distance(position3, ghost.transform.position);
            float max_val = Mathf.Max(dist1, Mathf.Max(dist2, dist3));
            if (max_val == dist1) { ghost.transform.position = position1; }
            else if (max_val == dist2) { ghost.transform.position = position2; }
            else if (max_val == dist3) { ghost.transform.position = position3; }

        }
    }

    void ExplosionShot()
    {
        mesh.enabled = false;
        collider.enabled = false;
        system.Play();
        timeStamp = Time.time + coolDownPeriodInSeconds;
        exploded = true;
        audioScream.enabled = false;
        audioExplosion.Play();
        changePlayerPos = true;
    }

    void ExplosionHit()
    {
        mesh.enabled = false;
        collider.enabled = false;
        system.Play();
        timeStamp = Time.time + coolDownPeriodInSeconds;
        exploded = true;
        audioScream.enabled = false;
        audioExplosion.Play();

        Vignette tempVignette;
        if (volume.profile.TryGet<Vignette>(out tempVignette))
        {
            vignette = tempVignette;
        }

        vignette.intensity.value += 0.2f;
    }

    void OnTriggerEnter(Collider other)
    {
        ExplosionHit();
    }

    void OnMouseOver()
    {
        if (EquippedObjects.weaponUse && Input.GetMouseButtonDown(1) && (timeStamp <= Time.time))
        {
            ExplosionShot();
            timeStamp = Time.time + coolDownPeriodInSeconds;
        }
    }
}
