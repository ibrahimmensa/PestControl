using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    public ParticleSystem AttackParticle;
    // Start is called before the first frame update

    public void ParticlePlayer()
    {
        AttackParticle.Play();
    }
}
