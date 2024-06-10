using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Particle
{
    private GameObject gameObject;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    private CircleCollider2D collider;

    private float charge_uc { get; }

    public Particle(Vector3 initialPos, float mass, float charge_uc) {
        this.charge_uc = charge_uc;
        gameObject = new GameObject();
        gameObject.name = "Particle";
        gameObject.transform.localScale = new Vector3(.33f,.33f,1);

        gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Circle");
        spriteRenderer.size = new Vector2(1,1);
        if (charge_uc < 0) {
            spriteRenderer.color = Color.yellow;
        } else if (charge_uc > 0) {
            spriteRenderer.color = Color.red;
        }
        else {
            spriteRenderer.color = Color.green;
        }

        gameObject.AddComponent<Rigidbody2D>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.mass = mass;
        rigidbody.gravityScale = 0;
        rigidbody.sharedMaterial = Resources.Load<PhysicsMaterial2D>("Particle Material");

        gameObject.AddComponent<CircleCollider2D>();
        collider = gameObject.GetComponent<CircleCollider2D>();

        gameObject.transform.position = initialPos;
    }

    private bool doPhyz;

    public IEnumerator Start(List<Particle> particles) {
        doPhyz = true;
        while (doPhyz) {
            Vector3 totalEField = new Vector3(0,0);
            foreach (Particle p in particles) {
                if (p == this) continue;

                var disp = VectorUtil.Displacement(p.GetPosition(), gameObject.transform.position);
                if (disp.magnitude == 0) continue;

                totalEField += disp * (9 * p.charge_uc) / ((float) Math.Pow(disp.magnitude, 3));
            }
            if (!Input.GetKey(KeyCode.Space)) {
                rigidbody.AddForce((Vector2) (totalEField * charge_uc), ForceMode2D.Force);
            } else {
                rigidbody.velocity = Vector2.zero;
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
