using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private GameObject pfWaterProjectile;
    [SerializeField] private Transform spawnWaterPosition;    

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    int elapsedFrames = 0;
    public int interpolationFramesCount = 45;
    Vector3 initialFoward;


    private void Awake(){
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update(){
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask)){
        //transform.position = raycastHit.point;
        mouseWorldPosition = raycastHit.point;

        }

        if(starterAssetsInputs.shoot){
            Vector3 aimDir = (mouseWorldPosition - spawnWaterPosition.position).normalized;
            GameObject projectile = Instantiate(pfWaterProjectile,spawnWaterPosition.position,Quaternion.LookRotation(aimDir,Vector3.up));
            Debug.Log(spawnWaterPosition.position);
            Debug.Log(aimDir);
            //.transform.forward = aimDir;
            starterAssetsInputs.shoot = false;
        }

        if(starterAssetsInputs.aim){
            if (elapsedFrames<= 0)
            {   
                initialFoward = transform.forward;
            }
            
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;


            //Vector3 interpolatedPosition = Vector3.Lerp(Vector3.up, Vector3.forward, interpolationRatio);
            transform.forward = Vector3.Lerp(initialFoward, aimDirection, interpolationRatio);

            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
            

        }else{
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            }

        
    }

}