using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform camera;
    public float speed = 2f;
    public float rayDist = 100f;
    public LayerMask ground;    

    void Update(){
        Ray ray = new Ray(camera.position, camera.forward);      

        if(Physics.Raycast(ray, out RaycastHit hit, rayDist, ground)){
            if(hit.collider.GetComponent<Terrain>() != null){
                Vector3 moveDir = camera.forward;
                moveDir.y = 0f;
                moveDir.Normalize();
                transform.position += moveDir * speed * Time.deltaTime;}
        }
    }
} 
