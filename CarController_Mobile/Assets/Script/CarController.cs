using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Com base neste Script - vamos melhorar nosso carro e deixa-lo mais tunano 😜
//CRIAR UM CARRO COM MOTOR 4 POR 4
//CRIAR UM CARRO COM FREIO NAS QUATRO RODAS
//CRIAR UM JIP E UM CAMINHÃO.😱 
//CRIE UM FREIO DE MÃO .
//ACENDER E APAGAR A LUZ DO CARRO

public class CarController : MonoBehaviour
{    
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";


    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;



    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRighttWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

   
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRighttWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransformr;
    [SerializeField] private Transform rearRightWheelTransform;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate() 
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        RestartPosition(); 
    }

    //Atualização da posição do carro
    private void RestartPosition()
    {
       if(Input.GetKey("r"))
       {
           Debug.Log("RestartPosition");
           transform.position = new Vector3(3f, transform.position.y, transform.position.z);
           transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       }
    }

    //capturar os eventos de input
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }


    //Lidar com o Motor
    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRighttWheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();   
    }

    //Lidar com o Freio
    private void ApplyBreaking()
    {
        frontRighttWheelCollider.brakeTorque = currentBreakForce;
        frontLeftWheelCollider.brakeTorque = currentBreakForce; 
    }

    //Lidar com a Direção
    private void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRighttWheelCollider.steerAngle = currentSteerAngle;
    }

    //Aualização das rodas
    private void UpdateWheels()
    {
       UpdateSingleWheelCollider(frontLeftWheelCollider, frontLeftWheelTransform);
       UpdateSingleWheelCollider(frontRighttWheelCollider, frontRighttWheelTransform);
       UpdateSingleWheelCollider(rearRightWheelCollider, rearRightWheelTransform);
       UpdateSingleWheelCollider(rearLeftWheelCollider, rearLeftWheelTransformr);
       
    }

    //Sincronização das rodas
    private void UpdateSingleWheelCollider( WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos,  out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

}
