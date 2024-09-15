using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public Animator animator;
    public string animationStateName;
    public ParticleSystem parentParticleSystem;

    private bool hasStarted = false;

    void Start()
    {
        // Asegurarse de que el Animator está asignado
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Detener el sistema de partículas al inicio
        if (parentParticleSystem == null)
        {
            Debug.LogError("El sistema de partículas no está asignado.");
            return;
        }

        parentParticleSystem.Stop();
    }

    void Update()
    {
        // Obtener información del estado actual de la animación
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Verificar si el estado actual es el deseado
        if (stateInfo.IsName(animationStateName))
        {
            // Obtener el tiempo normalizado de la animación
            float normalizedTime = stateInfo.normalizedTime % 1;

            if (!hasStarted && normalizedTime >= 0)
            {
                // Iniciar el sistema de partículas al comienzo de la animación
                hasStarted = true;
                parentParticleSystem.Play();
            }

            // Opcional: Detener el sistema de partículas al final de la animación
            // if (normalizedTime >= 1)
            // {
            //     parentParticleSystem.Stop();
            // }
        }
        else
        {
            // Reiniciar el estado cuando la animación cambia
            hasStarted = false;
        }
    }
}
