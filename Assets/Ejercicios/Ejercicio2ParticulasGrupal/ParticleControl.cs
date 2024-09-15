using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public Animator animator;
    public string animationStateName;
    public ParticleSystem parentParticleSystem;

    private bool hasStarted = false;

    void Start()
    {
        // Asegurarse de que el Animator est� asignado
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Detener el sistema de part�culas al inicio
        if (parentParticleSystem == null)
        {
            Debug.LogError("El sistema de part�culas no est� asignado.");
            return;
        }

        parentParticleSystem.Stop();
    }

    void Update()
    {
        // Obtener informaci�n del estado actual de la animaci�n
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Verificar si el estado actual es el deseado
        if (stateInfo.IsName(animationStateName))
        {
            // Obtener el tiempo normalizado de la animaci�n
            float normalizedTime = stateInfo.normalizedTime % 1;

            if (!hasStarted && normalizedTime >= 0)
            {
                // Iniciar el sistema de part�culas al comienzo de la animaci�n
                hasStarted = true;
                parentParticleSystem.Play();
            }

            // Opcional: Detener el sistema de part�culas al final de la animaci�n
            // if (normalizedTime >= 1)
            // {
            //     parentParticleSystem.Stop();
            // }
        }
        else
        {
            // Reiniciar el estado cuando la animaci�n cambia
            hasStarted = false;
        }
    }
}
