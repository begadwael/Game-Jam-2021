using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class InputHandler : MonoBehaviour
{
    [SerializeField] float mouseSensitivity=0.5f;
    Vector2 lookInput;
    Vector2 movement;
    bool Jump,Crouch,Run,Shoot;
    public Action onFire2;
    public Action onReload;
    public Action onE;
    public static InputHandler instance;
    private void Awake()
    {
        if(instance!=null){
            Destroy(this);
        }else
        {
            instance=this;
        }
    }
    public Vector2 GetCameraInput(){
        return lookInput*mouseSensitivity;
    }
    public Vector2 GetMovement(){
        //optionaly some blocking etc.
        return movement;
    }
    public bool IsRunning{
        get{return Run;}
    }
    public bool IsCrouching{
        get{return Crouch;}
    }
    public bool IsJumping{
        get{return Jump;}
    }
    public bool IsShooting{
        get{return Shoot;}
    }
    #region MethodsCalledByPlayerController
    public void OnLook(InputValue value){
        lookInput=value.Get<Vector2>();
    }
    public void OnMove(InputValue value){
        movement=value.Get<Vector2>();
    }
    public void OnJump(InputValue value){
        Jump=value.isPressed;
    }
    public void OnCrouch(InputValue value){
        Crouch=value.isPressed;
    }
    public void OnRun(InputValue value){
        Run=value.isPressed;
    }
    public void OnFire2(InputValue value){
        if(onFire2!=null){
            onFire2();
        }
    }
    public void OnFire1(InputValue value){
        Shoot=value.isPressed;
    }
    public void OnReload(InputValue value){
        if(onReload!=null){
            onReload();
        }
    }
    public void OnE(InputValue value){
        if(onE!=null){
            onE();
        }
    }
    #endregion
}
