using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Particle3D
{
    private GameObject gameObject;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private Rigidbody rigidbody;
    private SphereCollider collider;

    private float charge_uc { get; }

    public Particle3D(Vector3 initialPos, float mass, float charge_uc) {
        this.charge_uc = charge_uc;
        gameObject = new GameObject();
        gameObject.name = "Particle";
        gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

        gameObject.AddComponent<MeshRenderer>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        gameObject.AddComponent<MeshFilter>();
        meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh = Resources.Load<Mesh>("sphere");
        if (charge_uc < 0) {
            meshRenderer.material = Resources.Load<Material>("Materials/Negative");
        } else if (charge_uc > 0) {
            meshRenderer.material = Resources.Load<Material>("Materials/Positive");
        } else {
            meshRenderer.material = Resources.Load<Material>("Materials/Neutral");
        }

        gameObject.AddComponent<Rigidbody>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.mass = mass;
        rigidbody.useGravity = false;

        gameObject.AddComponent<SphereCollider>();
        collider = gameObject.GetComponent<SphereCollider>();
        collider.sharedMaterial = Resources.Load<PhysicMaterial>("Particle Mat 3D");

        gameObject.transform.position = initialPos;
    }

    private bool doPhyz;

    public IEnumerator Start(List<Particle3D> particles) {
        doPhyz = true;
        while (doPhyz) {
            Vector3 totalEField = Vector3.zero;
            foreach (Particle3D p in particles) {
                if (p == this) continue;

                var disp = VectorUtil.Displacement(p.GetPosition(), gameObject.transform.position);
                if (disp.magnitude == 0) continue;

                totalEField += disp * (450 * p.charge_uc) / ((float) Math.Pow(disp.magnitude, 3));
            }

            if (!Input.GetKey(KeyCode.Space)) {
                rigidbody.AddForce(totalEField * charge_uc, ForceMode.Force);
                rigidbody.AddForce(Vector3.Cross(charge_uc * rigidbody.velocity, MagneticUI.getMagneticField()), ForceMode.Force);
            } else {
                rigidbody.velocity = Vector3.zero;
            }
            yield return new WaitForFixedUpdate();
        }
    }
    
    public void Destroy() {
        GameObject.Destroy(gameObject);
        doPhyz = false;
    }
    public Vector3 GetPosition() {
        return gameObject.transform.position;
    }
}
