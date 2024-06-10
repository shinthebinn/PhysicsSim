using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ParticleManager : MonoBehaviour
{
    List<Particle> particles = new List<Particle>();

    public TextMeshProUGUI particleCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int cachedSize = 0;
    // Update is called once per frame
    void Update()
    {
        if (particles.Count != cachedSize) {
            particleCounter.text = particles.Count + " Active Particles";
        }
        cachedSize = particles.Count;

        if (Input.GetKeyDown(KeyCode.G)) {
            var p = new Particle(CameraUtils.GetMouseWorldPos(), UIManager.getIntendedMass(), UIManager.getIntendedCharge());
            StartCoroutine(p.Start(particles));
            particles.Add(p);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            DeleteParticle(0);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            DeleteParticle(particles.Count - 1);
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            ClearAllParticles();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadSceneAsync("Menu");
        }
    }

    private void DeleteParticle(int index) {
        if (particles.Count == 0) {
            StartCoroutine(FlashText());
            return;
        }
        int clampedIndex = Math.Clamp(index, 0, particles.Count-1);

        particles[clampedIndex].Destroy();
        particles.RemoveAt(clampedIndex);
    }

    private void ClearAllParticles() {
        foreach (Particle p in particles) {
            p.Destroy();
        }

        particles.Clear();
    }

    private IEnumerator FlashText() {
        for (int i = 0; i<3; i++) {
            particleCounter.color = Color.red;
            yield return new WaitForSeconds(.05f);
            particleCounter.color = Color.white;
            yield return new WaitForSeconds(.05f);
        }
    }
}
