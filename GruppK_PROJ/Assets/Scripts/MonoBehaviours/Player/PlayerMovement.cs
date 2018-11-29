﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public SaveData playerSaveData;
    public float turnSmoothing = 8f;
    public float speedDampTime = 0.1f;
    public float slowingSpeed = 0.175f;
    public float turnSpeedThreshold = 0.5f;
    

    private Interactable currentInteractable;
    private Vector3 destinationPosition;
    private bool holdForReacion = false;



    private readonly int hashSpeedPara = Animator.StringToHash("Speed");


    public const string startingPositionKey = "starting position";


    private const float stopDistanceProportion = 0.1f;
    private const float navMeshSampleDistance = 4f;


    private void Start()
    {
        agent.updateRotation = false;

        string startingPositionName = "";
        playerSaveData.Load(startingPositionKey, ref startingPositionName);
        Transform startingPosition = StartingPosition.FindStartingPosition(startingPositionName);

        transform.position = startingPosition.position;
        transform.rotation = startingPosition.rotation;

        destinationPosition = transform.position;
    }


    /*private void OnAnimatorMove()
    {
        agent.velocity = animator.deltaPosition / Time.deltaTime;
    }*/

    private void Update()
    {
//        Debug.Log(GetInteractionBool());
            if (agent.pathPending)
                return;

            float speed = agent.desiredVelocity.magnitude;

            if (agent.remainingDistance <= agent.stoppingDistance * stopDistanceProportion)
                Stopping(out speed);
            else if (agent.remainingDistance <= agent.stoppingDistance)
                Slowing(out speed, agent.remainingDistance);
            else if (speed > turnSpeedThreshold)
                Moving();

            animator.SetFloat(hashSpeedPara, speed, speedDampTime, Time.deltaTime);   
    }


    private void Stopping (out float speed)
    {
        agent.isStopped = true;

        transform.position = destinationPosition;
        speed = 0f;

        if (currentInteractable)
        {
            transform.rotation = currentInteractable.interactionLocation.rotation;
            currentInteractable.Interact();
            currentInteractable = null;
        }
    }


    private void Slowing (out float speed, float distanceToDestination)
    {
        agent.isStopped = true;

        float proportionalDistance = 1f - distanceToDestination / agent.stoppingDistance;

        Quaternion targetRotation = currentInteractable ? currentInteractable.interactionLocation.rotation : transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, proportionalDistance);

        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, slowingSpeed * Time.deltaTime);

        speed = Mathf.Lerp(slowingSpeed, 0f, proportionalDistance);
    }


    private void Moving ()
    {
        Quaternion targetRotation = Quaternion.LookRotation(agent.desiredVelocity);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
    }


    public void OnGroundClick(BaseEventData data)
    {
        if (holdForReacion)
        {
            return;
        }
        else
        {
            currentInteractable = null;
            PointerEventData pData = (PointerEventData)data;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(pData.pointerCurrentRaycast.worldPosition, out hit, navMeshSampleDistance, NavMesh.AllAreas))
                destinationPosition = hit.position;
            else
                destinationPosition = pData.pointerCurrentRaycast.worldPosition;
            agent.SetDestination(destinationPosition);
            agent.isStopped = false;
        }
    }

    public void OnInteractableClick(Interactable interactable)
    {
        if (holdForReacion)
        {
            return;
        }
        else
        {
            currentInteractable = interactable;
            destinationPosition = currentInteractable.interactionLocation.position;
            agent.SetDestination(destinationPosition);
            agent.isStopped = false;
        }
    }

    public void PauseUnpauseReaction(bool mode)
    {
        if (mode == false)
        {

        }
            holdForReacion = mode;
    }

    public bool GetInteractionBool()
    {
        return holdForReacion;
    }

}
